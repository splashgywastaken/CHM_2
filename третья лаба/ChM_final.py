# u - функция исходная, du - производная, ddu - вторая производная
# a=левая гр, b = правая гр
# A, B - значения в границах
import math
import numpy as np

# N=50
# a=-1
# b=1
# h=(b-a)/N
# alpha=0
# eps=0.001
# B=1
# A=-2
# L=15
# ICOD=-1
f = open('output.txt', 'a')
file_input = open('data.txt', 'r')
input_str = file_input.readline()
a = int(input_str)  # левый край отрезка
input_str = file_input.readline()
b = int(input_str)  # правый край отрезка
input_str = file_input.readline()
N = int(input_str)  # правый край отрезка
input_str = file_input.readline()
eps = float(input_str)  # точность нахождения решения
input_str = file_input.readline()
L = int(input_str)  # предельное число операций
input_str = file_input.readline()
alpha = float(input_str)  # предельное число операций
input_str = file_input.readline()
A = float(input_str)  # точность нахождения решения
input_str = file_input.readline()
B = int(input_str)  # предельное число операций
input_str = file_input.readline()

h = (b - a) / N
file_input.close()
print(a, b, N, eps, L, A, B)


def exact_solution(x):
    return x ** 2


def derrivative_exact_solution(x):
    return 2 * x


flag_IER = True
iterations_count = 0  # ДЛЯ ИТЕРАЦИЙ В БИСЕКШН

if N < 0 or L <= 0 or eps < 0:
    flag_IER = False
    ICOD = 2
    print('ICOD=', ICOD, ':Invalid Values', file=f)
while flag_IER:
    def xi():
        x = np.zeros(N + 1)
        for i in range(N + 1):
            x[i] = float(a + i * h)
        return x


    x = xi()

    # функции первоначальной задачи коши
    def f1(x, u, v):
        return v

    # Вторая производная
    def f2(x, u, v):
        return 2


    # Рунгекут 4 порядка
    def RungeKut(u, v, alpha):
        u[0] = alpha
        v[0] = A
        k1 = np.zeros(2)
        k2 = np.zeros(2)

        for i in range(N):
            k1[0] = (h * f1(x[i], u[i], v[i]))
            k1[1] = (h * f2(x[i], u[i], v[i]))

            k2[0] = (h * f1(x[i] + h, u[i] + k1[0], v[i] + k1[1]))
            k2[1] = (h * f2(x[i] + h, u[i] + k1[0], v[i] + k1[1]))

            u[i + 1] = (u[i] + 0.5 * (k1[0] + k2[0]))
            v[i + 1] = (v[i] + 0.5 * (k1[1] + k2[1]))
        return u, v


    u = np.zeros(N + 1)
    v = np.zeros(N + 1)
    u, v = RungeKut(u, v, alpha)

    # количество итераций
    # phi(alpha)

    def fiAlpha(alpha):
        # В тмпу хранятся приближенные значения точного решения функции
        # В тмпв знач. первой производной функции
        tmpU, tmpV = RungeKut(u, v, alpha)
        # Значение функции на границе - В, где В - значение производной функции с права
        fiAlpha = tmpU[N] - B
        return fiAlpha


    def different_sign(x, y):
        return x * y < 0


    # Фи от альфа задали, теперь нужно решить фи(альфа)=0:
    # Для решения полученного уравнения обычно применяют один из трех
    # методов: половинного деления
    # МЕТОД ПОЛОВИННОГО ДЕЛЕНИЯ
    # НО ДЛЯ НАЧАЛА НЕОБХОДИМО ОПРЕДЕЛИТЬ ПРАВУЮ ГРАНИЦУ
    # ЗНАЧЕНИЕ АЛЬФА ДВА ДОЛЖНО БЫТЬ ПОСЧИТАНО АВТОМАТИЧЕСКИ

    # фи(альфа) вблизи корня убывает или возрастает, выберем дельту, и рассмотрим как фи будет
    # изменяться при изменении альфа

    # Агоритм, который разобран по примеру из методички
    def searching_a2(alpha1):
        phi_alpha1 = fiAlpha(alpha1)
        delta = 1.0
        alpha2 = alpha1 + delta
        phi_alpha2 = fiAlpha(alpha2)
        flag_reversed = False
        while not different_sign(phi_alpha1, phi_alpha2):
            alpha2 = alpha1 + delta
            phi_alpha2 = fiAlpha(alpha2)
            if phi_alpha1 < 0:
                if not (phi_alpha2 > phi_alpha1 and flag_reversed):
                    delta += 0.2
                elif phi_alpha2 > phi_alpha1 and flag_reversed:
                    delta -= 0.2
                elif phi_alpha2 < phi_alpha1:
                    delta = delta * (-1)
                    flag_reversed = True
            if phi_alpha1 > 0:
                if phi_alpha2 > phi_alpha1:
                    delta = delta * (-1)
                    flag_reversed = True
                else:
                    if not phi_alpha2 < phi_alpha1 and flag_reversed:
                        delta += 0.2
                    if phi_alpha2 < phi_alpha1 and flag_reversed:
                        delta -= 0.2
        return alpha2


    # print(alpha)
    alpha2 = searching_a2(alpha)
    # print(alpha2)


    def bisection(neg_point, pos_point, epsilon):
        global flag_IER
        global iterations_count
        iterations_count += 1
        if iterations_count > L:
            print('ICOD = 1:Number of values is too big', file=f)
            flag_ICOD2 = False
            return None
        average_point = (pos_point + neg_point) / 2  # Средняя точка между концами интервала
        if abs(neg_point - pos_point) < epsilon:  # Основное условие для нахождения нуля функции
            return average_point
        test_value = fiAlpha(average_point)  # Значение функции в средней точке
        if test_value > 0:
            return bisection(neg_point, average_point, epsilon)
        elif test_value < 0:
            return bisection(average_point, pos_point, epsilon)
        return average_point


    result = bisection(alpha, alpha2, eps)
    print('Фи в альфа*', fiAlpha(result))
    print(result)

    # ВЫВОДИМ ЗАГОЛОВОК
    if not flag_IER:
        break
    print('ICOD = 0:No mistakes', file=f)
    print('Number of iterations', iterations_count, file=f)
    print('Final value of shooting parametr', result, file=f)
    str0 = "   x"
    str1 = "     y"
    str2 = "    deltaU"
    str3 = "  y'"
    str4 = "        deltaU'"
    print('{0:8s}{1:14s}{2:14s}{3:14s}{4:14s}'.format(str0, str1, str2, str3, str4))

    # ______________________________-
    # ЗАПИСЬ В ФАЙЛ
    f = open('output.txt', 'a')
    print('{0:8s}{1:14s}{2:14s}{3:14s}{4:14s}'.format(str0, str1, str2, str3, str4), file=f)
    # __________________________________

    for i in np.arange(0, N + 1):
        xi = x[i]
        y1i = exact_solution(x[i])
        deltau = abs(exact_solution(x[i]) - u[i])
        y_ = derrivative_exact_solution(x[i])
        deltau_ = abs(derrivative_exact_solution(x[i]) - v[i])
        print('{0:8.5f}{1:14.5e}{2:14.5e}{3:14.5e}{4:14.5e}'.format(xi, y1i, deltau, y_, deltau_))
        print('{0:8.5f}{1:14.5e}{2:14.5e}{3:14.5e}{4:14.5e}'.format(xi, y1i, deltau, y_, deltau_), file=f)
    f.close()

    flag_IER = False
