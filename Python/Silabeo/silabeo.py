
class Silabeador:
    def parse(self, text):
        result = []
        syllabe = ""
        
        for k in range(len(text)):
            letter = text[k]
            if is_vowel(letter):
                syllabe += letter
                result.append(syllabe)
                syllabe = ""
            elif is_ending_consonant(letter) and not use_next_letter(text, k + 1, letter):
                result[len(result) - 1] += letter
            else:
                syllabe += letter
                
        if len(syllabe) > 0:
            result.append(syllabe)
            
        return result
        
def is_vowel(letter):
    return letter in "aeiou"

def is_ending_consonant(letter):
    return letter in "rl"

def use_next_letter(text, position, letter):
    if position >= len(text):
        return False
        
    if is_vowel(text[position]):
        return True
        
    if text[position] == letter:
        return True
    
    return False
        