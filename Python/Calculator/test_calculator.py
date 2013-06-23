
import unittest
from calculator import Calculator

class CalculatorTests(unittest.TestCase):
    def test_add_two_numbers(self):
        calc = Calculator()
        result = calc.add(2, 3)
        self.assertEqual(5, result)

    def test_subtract_two_numbers(self):
        calc = Calculator()
        result = calc.subtract(2, 3)
        self.assertEqual(-1, result)

if __name__ == '__main__':
    unittest.main()