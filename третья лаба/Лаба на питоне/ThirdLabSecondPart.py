import numpy as np
import matplotlib.pyplot as plt
import math as m
from sympy import *
from prettytable import PrettyTable
from misc import correct_value, correct_array

# Границы отрезка, на котором ищется решение:
a, b = 0, 1
# Число отрезков разбиения
N = 10
# Точность решения нелинейного уравнения
epsilon = 1e-14
# Предельное число итераций
K = 1000
# Начальное значение пристрелочного параметра
alpha0, alpha1 = 1, 12
# Константы краевых уравнений
A, B, C = 0, 1, 6

# Шаг
h = (b - a) / N
iterations_count = 0  # Для итераций в методе секущих

x = Symbol('x')
u = Symbol('u')
v = Symbol('v')
w = Symbol('w')
# Задание функции
# f_exact_solution = x**4 + 2 * u**3 + 3 * v**2 + 4 * w
f_exact_function = 9 * u / (x ** 3) + v / (x ** 2) - w / x
f = lambdify([x, u, v, w], f_exact_function)


# Разные функции для работы программы
def x_i():
    array = np.zeros(N + 1)
    for i in range(N + 1):
        array[i] = float(a + i * h)
    return array


# Функция первоначальной задачи Коши
u_function = lambda input_x, input_u, input_v, input_w: input_v

v_function = lambda input_x, input_u, input_v, input_w: input_w

w_function = f


# Метод Рунге Кутта 2 порядка:
def RungeKut(input_alpha, f1=u_function, f2=v_function, f3=w_function):
    input_u = np.zeros(N + 1)
    input_v = np.zeros(N + 1)
    input_w = np.zeros(N + 1)
    input_u[N] = B  # u
    input_v[N] = input_alpha  # v
    input_w[N] = C  # w
    k1 = np.zeros(3)
    k2 = np.zeros(3)
    k3 = np.zeros(3)
    k4 = np.zeros(3)

    for i in reversed(range(0, N, 1)):
        # k1
        x_value = x_array[i + 1]
        uvw_values = [
            input_u[i + 1],
            input_v[i + 1],
            input_w[i + 1]
        ]
        uvw_part = uvw_values
        k1[0] = - h * f1(x_value, uvw_part[0], uvw_part[1], uvw_part[2])
        k1[1] = - h * f2(x_value, uvw_part[0], uvw_part[1], uvw_part[2])
        k1[2] = - h * f3(x_value, uvw_part[0], uvw_part[1], uvw_part[2])
        # k2
        uvw_part = [
            uvw_values[0] + k1[0] * 0.25,
            uvw_values[1] + k1[1] * 0.25,
            uvw_values[2] + k1[2] * 0.25
        ]
        k2[0] = - h * f1(x_value + h * 0.25, uvw_part[0], uvw_part[1], uvw_part[2])
        k2[1] = - h * f2(x_value + h * 0.25, uvw_part[0], uvw_part[1], uvw_part[2])
        k2[2] = - h * f3(x_value + h * 0.25, uvw_part[0], uvw_part[1], uvw_part[2])
        # k3
        uvw_part = [
            uvw_values[0] + k2[0] * 0.5,
            uvw_values[1] + k2[1] * 0.5,
            uvw_values[2] + k2[2] * 0.5
        ]
        k3[0] = - h * f1(x_value * 0.5, uvw_part[0], uvw_part[1], uvw_part[2])
        k3[1] = - h * f2(x_value * 0.5, uvw_part[0], uvw_part[1], uvw_part[2])
        k3[2] = - h * f3(x_value * 0.5, uvw_part[0], uvw_part[1], uvw_part[2])
        # k4
        uvw_part = [
            uvw_values[0] + k1[0] - 2 * k2[0] + k3[0],
            uvw_values[1] + k1[1] - 2 * k2[1] + k3[1],
            uvw_values[2] + k1[2] - 2 * k2[2] + k3[2]
        ]
        k4[0] = - h * f1(x_value + h, uvw_part[0], uvw_part[1], uvw_part[2])
        k4[1] = - h * f2(x_value + h, uvw_part[0], uvw_part[1], uvw_part[2])
        k4[2] = - h * f3(x_value + h, uvw_part[0], uvw_part[1], uvw_part[2])

        k = 1/6

        input_u[i] = uvw_values[0] + k * (k1[0] + 4 * k3[0] + k4[0])
        input_v[i] = uvw_values[1] + k * (k1[1] + 4 * k3[1] + k4[1])
        input_w[i] = uvw_values[2] + k * (k1[2] + 4 * k3[2] + k4[2])

    return input_u, input_v, input_w

 # x_value = x_array[i + 1]
        # k1[0] = - h * f1(x_value, input_u[i + 1], input_v[i + 1], input_w[i + 1])
        # k1[1] = - h * f2(x_value, input_u[i + 1], input_v[i + 1], input_w[i + 1])
        # k1[0] = - h * f3(x_value, input_u[i + 1], input_v[i + 1], input_w[i + 1])
        #
        # k2[0] = - h * f1(x_value + h, input_u[i + 1] + k1[0], input_v[i + 1] + k1[1], input_w[i + 1] + k1[2])
        # k2[1] = - h * f2(x_value + h, input_u[i + 1] + k1[0], input_v[i + 1] + k1[1], input_w[i + 1] + k1[2])
        # k2[2] = - h * f3(x_value + h, input_u[i + 1] + k1[0], input_v[i + 1] + k1[1], input_w[i + 1] + k1[2])
        #
        # input_u[i] = input_u[i + 1] + 0.5 * (k1[0] + k2[0])
        # input_v[i] = input_v[i + 1] + 0.5 * (k1[1] + k2[1])
        # input_w[i] = input_w[i + 1] + 0.5 * (k1[2] + k2[2])

# du/dx = v
f_u = u_function
# dv/dx = w
f_v = v_function
# dw/dx
f_w = f


def fi_alpha(input_alpha):
    rk_result, _, _ = RungeKut(input_alpha, f_u, f_v, f_w)
    fi_alpha = rk_result[0] - A
    return fi_alpha


def shooting_mehod():
    param_alpha0 = alpha0
    param_alpha1 = alpha1

    iterations_count = 0
    fi_alpha0 = fi_alpha(param_alpha0)
    fi_alpha1 = fi_alpha(param_alpha1)

    # Метод секущих для вычисления следующего приближения альфа
    try:
        param_alpha2 = param_alpha1 - fi_alpha1 * (param_alpha1 - param_alpha0) / (fi_alpha1 - fi_alpha0)
    except ZeroDivisionError:
        print('Деление на ноль перед циклом - 152')
        return 2, None, iterations_count

    fi = fi_alpha(param_alpha2)
    iterations_count += 1

    IER = 0
    while m.fabs(fi) > epsilon and iterations_count < K:
        iterations_count += 1
        param_alpha0 = param_alpha1
        param_alpha1 = param_alpha2
        fi_alpha0 = fi_alpha1
        fi_alpha1 = fi
        try:
            param_alpha2 = param_alpha1 - fi_alpha1 * (param_alpha1 - param_alpha0) / (fi_alpha1 - fi_alpha0)
        except ZeroDivisionError:
            print('Деление на ноль внутри цикла - 168')
            return 2, None, iterations_count
        fi = fi_alpha(param_alpha2)
        # Проверки на выход из итераций
        if iterations_count >= K:
            # Код выхода "количество итераций превысило максимум"
            IER = 1
            return IER, param_alpha2, iterations_count
        if m.fabs(fi) <= epsilon:
            # Код выхода "все вычисления прошли успешно"
            IER = 0
            return IER, param_alpha2, iterations_count
    return IER, param_alpha2, iterations_count


def plot(x, y, name, xlabel, ylabel, legend):
    plt.figure(figsize=(10, 6))
    if len(x) == 2:
        plt.plot(
            x[0], y[0],
            x[1], y[1]
        )
    else:
        plt.plot(
            x, y
        )
    plt.legend(legend)
    plt.grid(true)
    plt.title(name)
    plt.xlabel(xlabel)
    plt.ylabel(ylabel)


check = True
if N < 0 or K <= 0 or epsilon < 0:
    check = False
    IER = 2
    print('IER', IER, ':Неправильные значения параметров')
if check:
    x_array = x_i()

    IER, alpha, iterations_count = shooting_mehod()

    if IER == 0:
        print('EIR = 0:Безошибочная работа программы')
        print('Количество итераций', iterations_count)
        print('fi(alpha) =', fi_alpha(alpha))
        print('epsilon = ', epsilon)

    u_array, v_array, w_array = RungeKut(alpha, f_u, f_v, f_w)

    f = lambda x: x ** 3
    f_derivative = lambda x: 3 * x ** 2
    f_derivative2 = lambda x: 6 * x

    if IER == 0:
        f_array = np.zeros(N + 1)
        f_error = np.zeros(N + 1)
        fd_array = np.zeros(N + 1)
        fd_error = np.zeros(N + 1)
        fd2_array = np.zeros(N + 1)
        fd2_error = np.zeros(N + 1)
        for i in range(N + 1):
            f_array[i] = f(x_array[i])
            fd_array[i] = f_derivative(x_array[i])
            fd2_array[i] = f_derivative2(x_array[i])
        u_array = correct_array(f_array, u_array, epsilon)
        v_array = correct_array(fd_array, v_array, epsilon)
        w_array = correct_array(fd2_array, w_array, epsilon)
        alpha = correct_value(f_derivative(B), alpha, epsilon)

        th = ["x", "y", "deltaU", "y'", "deltaU'", "y''", "deltaU''"]
        # th = ["x", "y", "u", "y'", "v", "y''", "w"]
        td = []

        for i in np.arange(0, N + 1):
            td.append(x_array[i])

            td.append(f_array[i])

            f_error[i] = abs(f_array[i] - u_array[i])
            td.append(f_error[i])
            # td.append(u_array[i])

            td.append(fd_array[i])

            fd_error[i] = abs(fd_array[i] - v_array[i])
            td.append(fd_error[i])
            # td.append(v_array[i])

            td.append(fd2_array[i])

            fd2_error[i] = abs(fd2_array[i] - w_array[i])
            td.append(fd2_error[i])
            # td.append(w_array[i])

        columns = len(th)
        table = PrettyTable(th)
        td_data = td[:]
        while td_data:
            table.add_row(td_data[:columns])
            td_data = td_data[columns:]

        print('Конечное значение параметра пристрелки', alpha)
        print(table)

        plot([x_array, x_array], [f_array, u_array], "Графики функции Y", 'X', 'Y', ['Y', "U"])
        plot(x_array, f_error, "Погрешность для Y", 'X', 'Y', ['error Y'])
        plot([x_array, x_array], [fd_array, v_array], "Графики функции Y'", 'X', 'Y', ["Y'", "U'"])
        plot(x_array, fd_error, "Погрешность для Y'", 'X', 'Y', ["error Y'"])
        plot([x_array, x_array], [fd2_array, w_array], "Графики функции Y''", 'X', 'Y', ["Y''", "U''"])
        plot(x_array, fd2_error, "Погрешность для Y''", 'X', 'Y', ["error Y''"])
        plt.show()
    else:
        if IER == 1:
            print('EIR = 1: Количество итераций превысило установленный максимум')
        else:
            print('EIR = 2: Ошибка работы программы')
        print('Количество итераций:', iterations_count)
