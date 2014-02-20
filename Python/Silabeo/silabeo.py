
class Silabeador:
    def parse(self, text):
        result = []
        syllabe = ""
        lastsyllabe = ""
        
        for k in range(len(text)):
            letter = text[k]
            if is_vowel(letter):
                if len(syllabe) == 0 and is_diphthong(lastsyllabe, letter):
                    result[len(result) - 1] += letter
                    continue
                    
                syllabe += letter
                result.append(syllabe)
                lastsyllabe = syllabe
                syllabe = ""
            elif is_ending_consonant(letter) and not use_next_letter(text, k + 1, letter):
                result[len(result) - 1] += letter
            elif k == len(text) - 1:
                result[len(result) - 1] += letter
            else:
                syllabe += letter
                
        if len(syllabe) > 0:
            result.append(syllabe)
            
        return result
        
def is_vowel(letter):
    return letter in "aeiouáéíóú"

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

def is_diphthong(syllabe, letter):
    if len(syllabe) == 0:
        return False
        
    lastletter = syllabe[-1]
    
    if not is_vowel(lastletter):
        return False
        
    if is_open_vowel(lastletter) and is_open_vowel(letter):
        return False
        
    return True
    