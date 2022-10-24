Feature: API Test

A short summary of the feature


Scenario: Validate ZIP Test API
	Given I open resource file "expectedData.json" and save to "Expected API Result"
	When  I call API "ZIP_GET" and save response to "API Output"
	| Parameters | Values |
	| zip | 54401 |
	Then I validate response code for "API Output" is 200
	And  I validate API data "API Output" against expected result of "Expected API Result"

@tag1
Scenario: Validate Population Test API
	When I call API "Nation_Population_GET" and save response to "API Output"
	| Parameters | Values |
	| drilldowns | Nation |
	|   measures |Population|
	Then I validate response code for "API Output" is 200

	@tag1
Scenario: Validate University Test API
	When  I call API "University_GET" and save response to "API Output"
	| Parameters | Values |
	| country | United+States |
	Then I validate response code for "API Output" is 200
	

Scenario: Validate IP Test API
	When  I call API "IP_GET" and save response to "API Output"
	| Parameters | Values |
	| format | json |
	Then I validate response code for "API Output" is 200
