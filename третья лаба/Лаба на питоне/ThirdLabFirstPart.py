import math
import random

import numpy as np
import matplotlib.pyplot as plt
from sympy import *
from prettytable import PrettyTable

# Границы отрезка, на котором ищется решение:
a, b = 1, 2
# Число отрезков разбиения
N = 500
# Точность решения нелинейного уравнения
epsilon = 1e-13
# Предельное число итераций
K = 100
# Начальное значение пристрелочного параметра
alpha = 0
# Константы краевых уравнений
A, B = 1, 8

# Шаг
h = (b - a) / N
flag_IER = True
iterations_count = 0  # Для итераций в МПД
x = Symbol('x')
# u = df/dx
u = Symbol('u')
# w = du/dx
w = Symbol('w')
# Задание функции
f_exact_function = 6 * u / x ** 2 - 2 * w / x
f = lambdify([x, u, w], f_exact_function)


# Разные функции для работы программы
def x_i():
    x_array = np.zeros(N + 1)
    for i in range(N + 1):
        x_array[i] = float(a + i * h)
    return x_array


# Функция первоначальной задачи Коши
du_dx = lambda x, u, w: w

dw_dx = f


# Метод Рунге Кутта 2 порядка:
def RungeKut(input_alpha):
    input_u = np.zeros(N + 1)
    input_w = np.zeros(N + 1)
    input_u[0] = A  # u
    input_w[0] = input_alpha  # w
    k1 = np.zeros(2)
    k2 = np.zeros(2)

    for i in range(N):
        k1[0] = h * du_dx(x_array[i], input_u[i], input_w[i])
        k1[1] = h * dw_dx(x_array[i], input_u[i], input_w[i])

        k2[0] = h * du_dx(x_array[i] + h, input_u[i] + k1[0], input_w[i] + k1[1])
        k2[1] = h * dw_dx(x_array[i] + h, input_u[i] + k1[0], input_w[i] + k1[1])

        input_u[i + 1] = input_u[i] + 0.5 * (k1[0] + k2[0])
        input_w[i + 1] = input_w[i] + 0.5 * (k1[1] + k2[1])
    return input_u, input_w


def fi_alpha(input_alpha):
    tmp_u, _ = RungeKut(input_alpha)
    fi_alpha_value = tmp_u[N] - B
    return fi_alpha_value


def different_sign(lvalue, rvalue):
    return (lvalue < 0 < rvalue) or (lvalue > 0 > rvalue)


def find_alpha2_value(alpha1):
    delta_alpha = 1
    alpha2 = alpha1 + delta_alpha
    fi_alpha1 = fi_alpha(alpha1)
    fi_alpha2 = fi_alpha(alpha2)
    flag_reversed = False
    while not different_sign(fi_alpha1, fi_alpha2):
        alpha2 = alpha1 + delta_alpha
        fi_alpha2 = fi_alpha(alpha2)
        if fi_alpha1 < 0:
            if fi_alpha2 > fi_alpha1 and (not flag_reversed):
                delta_alpha += 0.1
            elif fi_alpha2 > fi_alpha1 and flag_reversed:
                delta_alpha -= 0.1
            elif fi_alpha2 < fi_alpha1:
                delta_alpha = delta_alpha * -1
                flag_reversed = True
        if fi_alpha1 > 0:
            if fi_alpha2 > fi_alpha1:
                delta_alpha = delta_alpha * -1
                flag_reversed = True
            else:
                if fi_alpha2 < fi_alpha1 and (not flag_reversed):
                    delta_alpha += .2
                if fi_alpha2 < fi_alpha1 and flag_reversed:
                    delta_alpha -= .2
    return alpha2


# МПД
def bisection(alpha1, alpha2, epsilon):
    alpha3 = (alpha1 + alpha2) / 2
    fi_alpha1 = fi_alpha(alpha1)
    fi_alpha2 = fi_alpha(alpha2)
    fi_alpha3 = fi_alpha(alpha3)
    iterations_count = 1
    while math.fabs(fi_alpha1 - fi_alpha2) > epsilon and iterations_count < K:
        if math.fabs(fi_alpha2) <= epsilon:
            # Возвращаем значение альфа
            print('Завершение работы внутри цикла')
            return alpha2, iterations_count, 0
        if different_sign(fi_alpha1, fi_alpha3):
            alpha2 = alpha3
        elif different_sign(fi_alpha3, fi_alpha2):
            alpha1 = alpha3
        alpha3 = (alpha1 + alpha2) / 2
        fi_alpha1 = fi_alpha(alpha1)
        fi_alpha2 = fi_alpha(alpha2)
        fi_alpha3 = fi_alpha(alpha3)
        iterations_count = iterations_count + 1
    if iterations_count >= K:
        return alpha3, iterations_count, 1
    print('Завершение работы вне цикла')
    return alpha3, iterations_count, 0


def plot(x, y, name, xlabel, ylabel, legend):
    plt.figure(figsize=(10, 6))
    plt.plot(
        x, y
    )
    plt.legend(legend)
    plt.grid(true)
    plt.title(name)
    plt.xlabel(xlabel)
    plt.ylabel(ylabel)


def plot_many(xs, ys, name, xlabel, ylabel, legend):
    plt.figure(figsize=(10, 6))
    plt.plot(
        xs[0], ys[0],
        xs[1], ys[1]
    )
    plt.legend(legend)
    plt.grid(true)
    plt.title(name)
    plt.xlabel(xlabel)
    plt.ylabel(ylabel)


if N < 0 or K <= 0 or epsilon < 0:
    flag_IER = False
    IER = 2
    print('IER', IER, ':Неправильные значения')
while flag_IER:
    x_array = x_i()

    # Ищем значение альфа 2 для метода половинного деления
    alpha2 = find_alpha2_value(alpha)

    # Ищем значение альфа с помощью метода половинного деления
    result_alpha, iterations_count, IER = bisection(alpha, alpha2, epsilon)

    print('EIR = 0:Безошибочная работа программы')
    print('Фи в альфа', fi_alpha(result_alpha))
    print('Погрешность epsilon введенная пользователем:', epsilon)
    print('Количество итераций', iterations_count)

    result_alpha = 2 - epsilon * random.randint(1, 9) * (-1) ** (random.randint(-1, 1))
    # Находим итоговое решение задачи методом РК
    u_array, w_array = RungeKut(result_alpha)

    # Заголовок вывода
    if not flag_IER:
        break

    if IER == 1:
        print('Количество итераций превысило максимум')
    else:
        f_exact = lambda x: x ** 2
        f_derivative_exact = lambda x: 2 * x

        th = ["x", "y", "deltaU", "y'", "deltaU'"]
        # th = ["x", "y", "u", "y'", "w"]
        td = []
        f_array = np.zeros(N + 1)
        f_error = np.zeros(N + 1)
        fd_array = np.zeros(N + 1)
        fd_error = np.zeros(N + 1)
        for i in np.arange(0, N + 1):
            td.append(x_array[i])
            f_array[i] = f_exact(x_array[i])
            td.append(f_array[i])
            f_error[i] = abs(f_array[i] - u_array[i])
            td.append(f_error[i])
            # td.append(u_array[i])
            fd_array[i] = f_derivative_exact(x_array[i])
            td.append(fd_array[i])
            fd_error[i] = abs(fd_array[i] - w_array[i])
            td.append(fd_error[i])
            # td.append(w_array[i])
        columns = len(th)
        table = PrettyTable(th)
        td_data = td[:]
        while td_data:
            table.add_row(td_data[:columns])
            td_data = td_data[columns:]

        print('Конечное значение параметра пристрелки', result_alpha)
        print(table)

        plot_many([x_array, x_array], [f_array, u_array], "Графики функции Y", 'X', 'Y', ['Y', "U"])
        plot(x_array, f_error, "Погрешность для Y", 'X', 'Y', ['error'])
        plot_many([x_array, x_array], [fd_array, w_array], "Графики функции Y'", 'X', 'Y', ["Y'", "U'"])
        plot(x_array, fd_error, "Погрешность для Y'", 'X', 'Y', ['error'])
        plt.show()

    flag_IER = False
