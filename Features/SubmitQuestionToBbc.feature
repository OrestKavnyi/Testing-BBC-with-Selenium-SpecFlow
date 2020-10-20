  Feature: SubmitQuestionToBbc
	To successfully submit my question to BBC
	all the required fields of the form must be filled in
	
  @NegativeTests
  Scenario Outline: Submit question to BBC with wrong input data
	Given Home page is open
	When i navigate to Share With Bbc page
	And i submit my question with
	| Key                    | Value                    |
	| Tell us your story     | <Tell us your story>     |
	| Name                   | <Name>                   |
	| I am over 16 years old | <I am over 16 years old> |
	| Terms of Service       | <Terms of Service>       |
	Then error message must be shown
  Examples:
  | Tell us your story | Name | I am over 16 years old | Terms of Service |
  | sb's story         |      | true                   | true             |
  |                    | Matt | true                   | true             |
  | Matt's story       | Matt | true                   | false            |
  | Matt's story       | Matt | false                  | true             |


  @NegativeTests
  @DataGenerator
  Scenario Outline: Submit a question to bbc with not accepted terms
  	Given Home page is open
	When i navigate to Share With Bbc page
	And i submit my question '<TestCase>'
	Then error message must be shown
  Examples:
  | TestCase  |
  | TestCase1 |
  | TestCase2 |
  | TestCase3 |
  | TestCase4 |
  | TestCase5 |