import numpy as np
import matplotlib.pyplot as plt
from sympy import *
from prettytable import PrettyTable
# Границы отрезка, на котором ищется решение:
a, b = -1, 1
# Число отрезков разбиения
N = 50
# Точность решения нелинейного уравнения
epsilon = 1e-11
# Предельное число итераций
K = 1000
# Начальное значение пристрелочного параметра
alpha0 = 0
alpha1 = 1
# Использовать коэффициенты A и B или mu1 и nu1
# Константы краевых уравнений
A, B, C = -2, 1, 2
# Шаг
h = (b-a) / N
flag_IER = True
iterations_count = 0 # Для итераций в МПД

x = Symbol('x')
u = Symbol('u')
v = Symbol('v')
w = Symbol('w')
# Задание функции
f_exact_solution = x ** 3
exact_solution = lambdify([x, u, v, w], f_exact_solution)
# Первая производная
fd_exact_solution = diff(f_exact_solution, x)
derivative_exact_solution = lambdify([x, u, v, w], fd_exact_solution)
# Вторая производная
f2d_exact_solution = diff(fd_exact_solution, )
derivative2_exact_solution = lambdify([x, u, v, w], f2d_exact_solution)
# Разные функции для работы программы
def x_i():
        array = np.zeros(N + 1)
        for i in range(N + 1):
            array[i] = float(a + i * h)
        return array

# Функция первоначальной задачи Коши
f1 = lambda input_x, input_u, input_v, input_w: input_v

f2 = lambda input_x, input_u, input_v, input_w: input_w

f3 = derivative2_exact_solution

# Метод Рунге Кутта 2 порядка:
def RungeKut(input_alpha):
    input_u = np.zeros(N + 1)
    input_v = np.zeros(N + 1)
    input_w = np.zeros(N + 1)
    input_u[N] = B # u
    input_v[N] = input_alpha # v
    input_w[N] = C # w
    k1 = np.zeros(3)
    k2 = np.zeros(3)

    for i in range(N, 1, -1):
        k1[0] = (h * f1(x_array[i], input_u[i], input_v[i], input_w[i]))
        k1[1] = (h * f2(x_array[i], input_u[i], input_v[i], input_w[i]))
        k1[2] = (h * f3(x_array[i], input_u[i], input_v[i], input_w[i]))

        k2[0] = (h * f1(x_array[i] + h, input_u[i] + k1[0], input_v[i] + k1[1], input_w[i] + k1[1]))
        k2[1] = (h * f2(x_array[i] + h, input_u[i] + k1[0], input_v[i] + k1[1], input_w[i] + k1[1]))
        k2[2] = (h * f3(x_array[i] + h, input_u[i] + k1[0], input_v[i] + k1[1], input_w[i] + k1[1]))

        input_u[i - 1] = input_u[i] + 0.5 * (k1[0] + k2[0])
        input_v[i - 1] = input_u[i] + 0.5 * (k1[1] + k2[1])
        input_w[i - 1] = input_w[i] + 0.5 * (k1[2] + k2[2])
    return input_u, input_v, input_w

def fiAlpha(input_alpha):
    # В тмпу хранятся приближенные значения точного решения функции
    # В тмпв знач. первой производной функции
    _, tmp_v, _ = RungeKut(input_alpha)
    # Значение функции на границе - В, где В - значение производной функции с права
    fi_alpha_value = tmp_v[N] - A
    return fi_alpha_value

# метод секущих
def secant(input_alpha0, input_alpha1):
    global flag_IER
    global iterations_count
    if iterations_count > K:
        print('IER = 1:Количество итераций слишком велико')
        flag_IER = False
        return None

    while iterations_count < K:
        fi_alpha0 = fiAlpha(input_alpha0)
        fi_alpha1 = fiAlpha(input_alpha1)
        alpha2 = alpha1 - (fi_alpha1 * (alpha1 - alpha0)) / (fi_alpha1 - fi_alpha0)
        if alpha2 < epsilon:
            return alpha2
        else:
            iterations_count += 1
            input_alpha0 = input_alpha1
            input_alpha1 = alpha2
    return
if N < 0 or K <= 0 or epsilon < 0:
    flag_IER = False
    IER = 2
    print('IER', IER, ':Неправильные значения параметров')
while flag_IER:

    x_array = x_i()
    u_array, v_array, w_array = RungeKut(alpha1)

    result_alpha = secant(alpha0, alpha1)

    print('Фи в альфа*', fiAlpha(result_alpha))
    print(result_alpha)

    # Заголовок вывода
    if not flag_IER:
        break

    th = ["x", "y", "deltaU", "y'", "deltaU'"]
    td = []
    for i in np.arange(0, N + 1):
        td.append(x_array[i])
        td.append(exact_solution(x_array[i], 0, 0, 0))
        td.append(abs(exact_solution(x_array[i], 0, 0, 0) - u_array[i]))
        td.append(derivative_exact_solution(x_array[i], 0, 0, 0))
        td.append(abs(derivative_exact_solution(x_array[i], 0, 0, 0) - w_array[i]))
    columns = len(th)
    table = PrettyTable(th)
    td_data = td[:]
    while td_data:
        table.add_row(td_data[:columns])
        td_data = td_data[columns:]

    print('EIR = 0:Безошибочная работа программы')
    print('Количество итераций', iterations_count)
    print('Конечное значение параметра пристрелки', result_alpha)

    print(table)