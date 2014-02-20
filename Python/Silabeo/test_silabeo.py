
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
        self.assertEqual(2, len(result))
        self.assertEqual("sa", result[0])
        self.assertEqual("la", result[1])

    def test_consonant_vowel_consonant_othervowel(self):
        sil = Silabeador()
        result = sil.parse("sale")
        self.assertEqual(2, len(result))
        self.assertEqual("sa", result[0])
        self.assertEqual("le", result[1])

    def test_consonant_vowel_doubleconsonant_othervowel(self):
        sil = Silabeador()
        result = sil.parse("carro")
        self.assertEqual(2, len(result))
        self.assertEqual("ca", result[0])
        self.assertEqual("rro", result[1])

    def test_word_having_ivowel(self):
        sil = Silabeador()
        result = sil.parse("carrito")
        self.assertEqual(3, len(result))
        self.assertEqual("ca", result[0])
        self.assertEqual("rri", result[1])
        self.assertEqual("to", result[2])

    def test_word_having_uvowel(self):
        sil = Silabeador()
        result = sil.parse("curro")
        self.assertEqual(2, len(result))
        self.assertEqual("cu", result[0])
        self.assertEqual("rro", result[1])

    def test_word_having_initial_vowel(self):
        sil = Silabeador()
        result = sil.parse("alaba")
        self.assertEqual(3, len(result))
        self.assertEqual("a", result[0])
        self.assertEqual("la", result[1])
        self.assertEqual("ba", result[2])

    def test_word_having_syllabe_ending_with_rconsonant(self):
        sil = Silabeador()
        result = sil.parse("alabar")
        self.assertEqual(3, len(result))
        self.assertEqual("a", result[0])
        self.assertEqual("la", result[1])
        self.assertEqual("bar", result[2])

    def test_word_having_syllabe_ending_with_lconsonant(self):
        sil = Silabeador()
        result = sil.parse("alto")
        self.assertEqual(2, len(result))
        self.assertEqual("al", result[0])
        self.assertEqual("to", result[1])

    def test_dyphthong(self):
        sil = Silabeador()
        result = sil.parse("paisaje")
        self.assertEqual(3, len(result))
        self.assertEqual("pai", result[0])
        self.assertEqual("sa", result[1])
        self.assertEqual("je", result[2])

    def test_false_dyphthong(self):
        sil = Silabeador()
        result = sil.parse("poema")
        self.assertEqual(3, len(result))
        self.assertEqual("po", result[0])
        self.assertEqual("e", result[1])
        self.assertEqual("ma", result[2])

    def test_word_ending_with_dconsonant(self):
        sil = Silabeador()
        result = sil.parse("ciudad")
        self.assertEqual(2, len(result))
        self.assertEqual("ciu", result[0])
        self.assertEqual("dad", result[1])

    def test_word_ending_with_aacute(self):
        sil = Silabeador()
        result = sil.parse("álamo")
        self.assertEqual(3, len(result))
        self.assertEqual("á", result[0])
        self.assertEqual("la", result[1])
        self.assertEqual("mo", result[2])

    def test_acute_open_vowel_in_false_diphtong(self):
        sil = Silabeador()
        result = sil.parse("ríos")
        self.assertEqual(2, len(result))
        self.assertEqual("rí", result[0])
        self.assertEqual("os", result[1])
        
    def test_udieresis(self):
        sil = Silabeador()
        result = sil.parse("santigüar")
        self.assertEqual(3, len(result))
        self.assertEqual("san", result[0])
        self.assertEqual("ti", result[1])
        self.assertEqual("güar", result[2])

    def test_soft_gconsontante_vowel(self):
        sil = Silabeador()
        result = sil.parse("guisante")
        self.assertEqual(3, len(result))
        self.assertEqual("gui", result[0])
        self.assertEqual("san", result[1])
        self.assertEqual("te", result[2])
                
if __name__ == '__main__':
    unittest.main()