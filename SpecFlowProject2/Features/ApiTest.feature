Feature: API Test

A short summary of the feature


Scenario: Validate ZIP Test API
	Given I open resource file "wrongExpectedData.json" and save to "Expected API Result"
	When I call API "ZIP_GET" and save response to "API Output"
		| Parameters | Values |
		| zip        | 54401  |
	Then I validate response code for "API Output" is 200
	And I validate API data "API Output" against expected result of "Expected API Result"

Scenario: Validate ZIP using Deserialization and then comparing
	Given I open resource file "expectedData.json" and save to "Expected API Result"
	When I call API "ZIP_GET" and save response to "API Output"
		| Parameters | Values |
		| zip        | 54401  |
	Then I validate response code for "API Output" is 200
	And I validate API data "API Output" against expected result of "Expected API Result" using model "SpecFlowProject2.Models.Location"

Scenario Outline: Validate ZIP Test API for Multiple Locations
	Given I open resource file "<expected result>" and save to "Expected API Result"
	When I call API "ZIP_GET" and save response to "API Output"
		| Parameters | Values |
		| zip        | <zip>  |
	Then I validate response code for "API Output" is 200
	And I validate API data "API Output" against expected result of "Expected API Result" using model "SpecFlowProject2.Models.Location"
Examples:
	| zip   | expected result                      |
	| 54401 | expectedData.json                    |
	| 54452 | LocationResults/expectedMerrill.json |

@tag1
Scenario: Validate Population Test API
	When I call API "Nation_Population_GET" and save response to "API Output"
		| Parameters | Values     |
		| drilldowns | Nation     |
		| measures   | Population |
	Then I validate response code for "API Output" is 200

@tag1
Scenario: Validate University Test API
	When I call API "University_GET" and save response to "API Output"
		| Parameters | Values        |
		| country    | United+States |
	Then I validate response code for "API Output" is 200
	

Scenario: Validate IP Test API
	When I call API "IP_GET" and save response to "API Output"
		| Parameters | Values |
		| format     | json   |
	Then I validate response code for "API Output" is 200
