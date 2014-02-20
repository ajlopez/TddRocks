
import unittest
from silabeo import Silabeo

class SilabeadorTests(unittest.TestCase):
    def test_one_vowel(self):
        result = Silabeo.parse("a")
        self.assertEqual(1, len(result))
        self.assertEqual("a", result[0])

    def test_consonant_vowel(self):
        result = Silabeo.parse("la")
        self.assertEqual(1, len(result))
        self.assertEqual("la", result[0])

    def test_consonant_vowel_consonant_vowel(self):
        result = Silabeo.parse("sala")
        self.assertEqual(2, len(result))
        self.assertEqual("sa", result[0])
        self.assertEqual("la", result[1])

    def test_consonant_vowel_consonant_othervowel(self):
        result = Silabeo.parse("sale")
        self.assertEqual(2, len(result))
        self.assertEqual("sa", result[0])
        self.assertEqual("le", result[1])

    def test_consonant_vowel_doubleconsonant_othervowel(self):
        result = Silabeo.parse("carro")
        self.assertEqual(2, len(result))
        self.assertEqual("ca", result[0])
        self.assertEqual("rro", result[1])

    def test_word_having_ivowel(self):
        result = Silabeo.parse("carrito")
        self.assertEqual(3, len(result))
        self.assertEqual("ca", result[0])
        self.assertEqual("rri", result[1])
        self.assertEqual("to", result[2])

    def test_word_having_uvowel(self):
        result = Silabeo.parse("curro")
        self.assertEqual(2, len(result))
        self.assertEqual("cu", result[0])
        self.assertEqual("rro", result[1])

    def test_word_having_initial_vowel(self):
        result = Silabeo.parse("alaba")
        self.assertEqual(3, len(result))
        self.assertEqual("a", result[0])
        self.assertEqual("la", result[1])
        self.assertEqual("ba", result[2])

    def test_word_having_syllable_ending_with_rconsonant(self):
        result = Silabeo.parse("alabar")
        self.assertEqual(3, len(result))
        self.assertEqual("a", result[0])
        self.assertEqual("la", result[1])
        self.assertEqual("bar", result[2])

    def test_word_having_syllable_ending_with_lconsonant(self):
        result = Silabeo.parse("alto")
        self.assertEqual(2, len(result))
        self.assertEqual("al", result[0])
        self.assertEqual("to", result[1])

    def test_dyphthong(self):
        result = Silabeo.parse("paisaje")
        self.assertEqual(3, len(result))
        self.assertEqual("pai", result[0])
        self.assertEqual("sa", result[1])
        self.assertEqual("je", result[2])

    def test_false_dyphthong(self):
        result = Silabeo.parse("poema")
        self.assertEqual(3, len(result))
        self.assertEqual("po", result[0])
        self.assertEqual("e", result[1])
        self.assertEqual("ma", result[2])

    def test_word_ending_with_dconsonant(self):
        result = Silabeo.parse("ciudad")
        self.assertEqual(2, len(result))
        self.assertEqual("ciu", result[0])
        self.assertEqual("dad", result[1])

    def test_word_ending_with_aacute(self):
        result = Silabeo.parse("álamo")
        self.assertEqual(3, len(result))
        self.assertEqual("á", result[0])
        self.assertEqual("la", result[1])
        self.assertEqual("mo", result[2])

    def test_acute_open_vowel_in_false_diphtong(self):
        result = Silabeo.parse("ríos")
        self.assertEqual(2, len(result))
        self.assertEqual("rí", result[0])
        self.assertEqual("os", result[1])
        
    def test_udieresis(self):
        result = Silabeo.parse("santigüar")
        self.assertEqual(3, len(result))
        self.assertEqual("san", result[0])
        self.assertEqual("ti", result[1])
        self.assertEqual("güar", result[2])

    def test_soft_gconsontante_vowel(self):
        result = Silabeo.parse("guisante")
        self.assertEqual(3, len(result))
        self.assertEqual("gui", result[0])
        self.assertEqual("san", result[1])
        self.assertEqual("te", result[2])

    def test_sconsonant_ending_syllable(self):
        result = Silabeo.parse("desastre")
        self.assertEqual(3, len(result))
        self.assertEqual("de", result[0])
        self.assertEqual("sas", result[1])
        self.assertEqual("tre", result[2])

    def test_yconsonant_ending_word(self):
        result = Silabeo.parse("Paraguay")
        self.assertEqual(3, len(result))
        self.assertEqual("Pa", result[0])
        self.assertEqual("ra", result[1])
        self.assertEqual("guay", result[2])

    def test_yconsonant_ending_syllable(self):
        result = Silabeo.parse("Huayco")
        self.assertEqual(2, len(result))
        self.assertEqual("Huay", result[0])
        self.assertEqual("co", result[1])

    def test_simple_triphthong(self):
        result = Silabeo.parse("hioides")
        self.assertEqual(2, len(result))
        self.assertEqual("hioi", result[0])
        self.assertEqual("des", result[1])
        
if __name__ == '__main__':
    unittest.main()