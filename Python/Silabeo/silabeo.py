
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
            else:
                syllabe += letter
                
        if len(syllabe) > 0:
            result.append(syllabe)
            
        return result
        

def is_vowel(letter):
    return letter in "aeio"