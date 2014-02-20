
import unittest
from silabeo import Silabeador

class SilabeadorTests(unittest.TestCase):
    def test_one_vowel(self):
        sil = Silabeador()
        result = sil.parse("a")
        self.assertEqual(1, len(result))
        self.assertEqual("a", result[0])

    def test_consonant_vowel(self):
        sil = Silabeador()
        result = sil.parse("la")
        self.assertEqual(1, len(result))
        self.assertEqual("la", result[0])

    def test_consonant_vowel_consonant_vowel(self):
        sil = Silabeador()
        result = sil.parse("sala")
        print(result)
        self.assertEqual(2, len(result))
        self.assertEqual("sa", result[0])
        self.assertEqual("la", result[1])

if __name__ == '__main__':
    unittest.main()