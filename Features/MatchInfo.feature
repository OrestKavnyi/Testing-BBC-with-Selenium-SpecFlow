Feature: MatchInfo
	In order to be sure about correctness of football matches results
	We should verify this information on both general scoreboard and particular match page 

  @PositiveTests
  Scenario Outline: Check that football match info displays correctly
	When i navigate to scoreboard '<championship>' '<month>'
	And i get to a particular match page '<team1>' '<team2>' '<score1>' '<score2>'
	Then it should display same match info
  Examples:
  | championship      | month | team1       | team2          | score1 | score2 |
  | Premier League    | Feb   | Watford     | Liverpool      | 3      | 0      |
  | Premier League    | Mar   | Chelsea     | Everton        | 4      | 0      |
  | Premier League    | Jul   | Arsenal     | Leicester City | 1      | 1      |
  | Italian Serie A   | Mar   | Parma       | SPAL           | 0      | 1      |
  | German Bundesliga | Jun   | FC Augsburg | RB Leipzig     | 1      | 2      |