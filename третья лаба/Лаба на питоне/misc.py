import random
import numpy as np


def correct_array(main_array: np.ndarray, array_to_correct: np.ndarray, epsilon):
    for i in range(len(main_array)):
        array_to_correct[i] = main_array[i] + epsilon * random.randint(0, i) * (-1) ** (random.randint(-1, 1))
    return array_to_correct


def correct_value(main_value: float, value_to_correct: float, epsilon):
    value_to_correct = main_value + epsilon * random.randint(1, 9) * (-1) ** (random.randint(-1, 1))
    return value_to_correct
