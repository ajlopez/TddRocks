
require "test/unit"

class Tokenizer
    def initialize(text)
        @text = text
    end
    
    def getTokens()
        @text.split
    end
end

class TestTokenizer < Test::Unit::TestCase
 
  def test_get_simple_letter
    tokenizer = Tokenizer.new("k")
    result = tokenizer.getTokens()
    assert_equal(1, result.length)
    assert_equal("k", result[0])
  end
 
  def test_get_simple_word
    tokenizer = Tokenizer.new("foo")
    result = tokenizer.getTokens()
    assert_equal(1, result.length)
    assert_equal("foo", result[0])
  end 
 
  def test_get_simple_word_skipping_spaces
    tokenizer = Tokenizer.new("  foo   ")
    result = tokenizer.getTokens()
    assert_equal(1, result.length)
    assert_equal("foo", result[0])
  end 
 
  def test_get_two_simple_word
    tokenizer = Tokenizer.new("foo bar")
    result = tokenizer.getTokens()
    assert_equal(2, result.length)
    assert_equal("foo", result[0])
    assert_equal("bar", result[1])
  end 
end