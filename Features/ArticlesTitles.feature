  Feature: ArticlesTitles
	In order to be sure that all articles are extracted correctly from DB
	We should verify their titles against expected ones

  Scenario: Check main article title
  	When i navigate to News page
	Then main article title should be 'Microphones to be muted in final US debate'

  Scenario: Check secondary articles titles
  	When i navigate to News page
	Then secondary articles titles should be
	| Title                                               |
	| Trump contradicts health chief on masks and vaccine |
	| Greece moves migrants to new camp after fire        |
	| Biden warning for UK over post-Brexit trade deal    |
	| Protesters topple conquistador statue in Colombia   |
	| What happened to Nujeen Mustafa?                    |
	| Heat ray 'was sought'  for protest near White House |

  Scenario: Check that search result contains keyword
    When i navigate to News page
  	And i put category name of main article in search bar
	Then title of first found article should be 'US election 2020: Trump and Biden feud over debate topics'