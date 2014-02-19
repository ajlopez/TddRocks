
import unittest
from silabeo import Silabeador

class SilabeadorTests(unittest.TestCase):
    def test_one_vowel(self):
        sil = Silabeador()
        result = sil.parse("a")
        self.assertEqual(1, len(result))
        self.assertEqual("a", result[0])

if __name__ == '__main__':
    unittest.main()