
require "test/unit"

class Tokenizer
    def getTokens(text)
        text.split
    end
end

class TestTokenizer < Test::Unit::TestCase
 
  def test_get_simple_letter
    tokenizer = Tokenizer.new()
    result = tokenizer.getTokens("k")
    assert_equal(1, result.length)
    assert_equal("k", result[0])
  end
 
  def test_get_simple_word
    tokenizer = Tokenizer.new()
    result = tokenizer.getTokens("foo")
    assert_equal(1, result.length)
    assert_equal("foo", result[0])
  end 
 
  def test_get_simple_word_skipping_spaces
    tokenizer = Tokenizer.new()
    result = tokenizer.getTokens("  foo   ")
    assert_equal(1, result.length)
    assert_equal("foo", result[0])
  end 
 
  def test_get_two_simple_word
    tokenizer = Tokenizer.new()
    result = tokenizer.getTokens("foo bar")
    assert_equal(2, result.length)
    assert_equal("foo", result[0])
    assert_equal("bar", result[1])
  end 
end