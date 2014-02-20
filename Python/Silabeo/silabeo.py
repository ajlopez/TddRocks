
class Silabeador:
    def parse(self, text):
        result = []
        syllable = ""
        lastsyllable = ""
        
        for k in range(len(text)):
            letter = text[k]
            if is_vowel(letter) or is_extended_vowel(letter, text, k):
                if len(syllable) == 0 and is_diphthong(lastsyllable, letter):
                    result[len(result) - 1] += letter
                    continue
                    
                syllable += letter
                result.append(syllable)
                lastsyllable = syllable
                syllable = ""
            elif is_ending_consonant(letter) and not use_next_letter(text, k + 1, letter):
                result[len(result) - 1] += letter
            elif k == len(text) - 1:
                result[len(result) - 1] += letter
            else:
                syllable += letter
                
        if len(syllable) > 0:
            result.append(syllable)
            
        return result
        
def is_vowel(letter):
    return letter in "aeiouáéíóú"

def is_extended_vowel(letter, text, position):
    if not letter in "yY":
        return False
    
    if position == len(text) - 1:
        return True
        
    nextletter = text[position + 1]
    
    if is_vowel(nextletter):
        return False
        
    return True
    
def is_open_vowel(letter):
    return letter in "aeoáéóíú"

def is_ending_consonant(letter):
    return letter in "rlns"

def use_next_letter(text, position, letter):
    if position >= len(text):
        return False
        
    if is_vowel(text[position]):
        return True
        
    if text[position] == letter:
        return True
    
    return False

def is_diphthong(syllable, letter):
    if len(syllable) == 0:
        return False
        
    lastletter = syllable[-1]
    
    if not is_vowel(lastletter):
        return False
        
    if is_open_vowel(lastletter) and is_open_vowel(letter):
        return False
        
    return True
    