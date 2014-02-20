
class Silabeador:
    def parse(self, text):
        result = []
        syllabe = ""
        
        for k in range(len(text)):
            letter = text[k]
            if is_vowel(letter):
                syllabe += letter
            else:
                if len(syllabe) > 0:
                    result.append(syllabe)
                syllabe = letter
                
        if len(syllabe) > 0:
            result.append(syllabe)
            
        return result
        

def is_vowel(letter):
    return letter in "ae"