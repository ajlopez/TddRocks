
import unittest
from calculator import Calculator

class CalculatorTests(unittest.TestCase):
    def test_add_two_integers(self):
        calc = Calculator()
        result = calc.add(2, 3)
        self.assertEqual(5, result)

if __name__ == '__main__':
    unittest.main()