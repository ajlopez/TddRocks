
require "test/unit"

class Tokenizer
    def initialize(text)
        @text = text
        @position = 0
    end
    
    def next_token()
        while @position < @text.length and @text[@position].ord <= 32
            @position = @position + 1
        end
        
        result = ''
        
        while @position < @text.length and @text[@position].ord > 32
            result = result + @text[@position]
            @position = @position + 1
        end
        
        if result == ''
            return nil
        end
        
        return result
    end
    
    def get_tokens()        
        tokens = []
        
        token = self.next_token
        
        while not token.nil?
            tokens.push(token)
            token = self.next_token
        end
        
        return tokens
    end
end

class TestTokenizer < Test::Unit::TestCase
 
  def test_get_simple_letter
    tokenizer = Tokenizer.new("k")
    result = tokenizer.get_tokens()
    assert_equal(1, result.length)
    assert_equal("k", result[0])
  end
 
  def test_get_simple_word
    tokenizer = Tokenizer.new("foo")
    result = tokenizer.get_tokens()
    assert_equal(1, result.length)
    assert_equal("foo", result[0])
  end 
 
  def test_get_simple_word_skipping_spaces
    tokenizer = Tokenizer.new("  foo   ")
    result = tokenizer.get_tokens()
    assert_equal(1, result.length)
    assert_equal("foo", result[0])
  end 
 
  def test_get_two_simple_word
    tokenizer = Tokenizer.new("foo bar")
    result = tokenizer.get_tokens()
    assert_equal(2, result.length)
    assert_equal("foo", result[0])
    assert_equal("bar", result[1])
  end 
end