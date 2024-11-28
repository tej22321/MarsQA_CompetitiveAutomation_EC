Feature: Adding Education to a user profile 
	
	Background: 
	  Given user log into MarsQA
	  And navigate to Education under profile tab


	@addEducation
	Scenario Outline: Add new education entry from json data file to user profile
	# Authorised person, trying to add a education entry to the profile 
	 When user add json data from json file with entry <index>
	 Then Verify Education record is created status is <expectedoutcome>

	 Examples:
	  | index | expectedoutcome |
	  | 0     | true            | #TC001first entry from Json file , to check with all valid fields
	  | 2     | false           | #TC004 Authorised person, trying to add a invalid education entry to the profile with College/University Name field value with numbers
	  | 3     | false           | #TC005 Authorised person, trying to add a education entry to the profile with College/University Name field value with alphanumeric
	  | 4     | false           | #TC006 Authorised person, trying to add a invalid education entry to the profile with College/University Name field value with special characters
	  | 5     | false           | #TC007 Authorised person, trying to add a invalid education entry to the profile with College/University Name field value with empty field
	  | 6     | false           | #TC008 Authorised person, trying to add a education entry to the profile with College/University Name field value with null value
	  | 7     | false           | #TC009 Authorised person, trying to add invalid education entry to the profile with College/University Name field value with just spaces in the filed
	  | 8     | false           | #TC010 Authorised person, trying to add invalid education entry to the profile with College/University Name text field value with very long string
	  | 9     | false           | #TC012 Authorised person, trying to add a invalid education entry to the profile with Degree Name field value with numbers
	  | 10    | false           | #TC013 Authorised person, trying to add a invalid education entry to the profile with Degree Name field value with alphanumeric
	  | 11    | false           | #TC014 Authorised person, trying to add a invalid education entry to the profile with Degree Name field value with specail characters
	  | 12    | false           | #TC015 Authorised person, trying to add a invalid education entry to the profile with Degree Name field value with empty value
	  | 13    | false           | #TC016 Authorised person, trying to add a invalid education entry to the profile with Degree Name field with NULL vaue
	  | 14    | false           | #TC017 Authorised person, trying to add a invalid education entry to the profile with Degree Name field with spacebar input
	  | 15    | false           | #TC018 Authorised person, trying to add a invalid education entry to the profile with Degree Name field with large string data
	  | 16    | true            | #TC019 Authorised person, trying to select a valid education entry to the profile with Country of College/University field by using arrow
	  | 17    | true            | #TC020 Authorised person, trying to add a valid education entry to the profile by navigating to the  Country of College/University field by selecting a letter
	  | 18    | true            | #TC021 Authorised person, trying to select a valid education entry to the profile with Title field by using arrow
	  | 19    | true            | #TC022 Authorised person, trying to select a valid education entry to the profile with Title field by selecting a letter
	  | 20    | true            | #TC023 Authorised person, trying to select a valid education entry to the profile with Year of graduaton  field by selecting a number
	  | 21    | true            | #TC024 Authorised person, trying to select a valid education entry to the profile with Year of graduaton  field by selecting usign up and down arrow

	@checkDuplicate
Scenario: Verify duplicate Education record is not allowed for duplicate entry
#TC002 Add a Eucation with valid input, with exisiting data
   When user add json data from json file with entry <index>
	And user adds same record again from json file of entry <index>
  Then Verify duplicate Education record is not allowed

	Examples:
	  | index |
	  | 0     | # first entry from Json file , to check with all valid fields


	  
	   @caseSensitiveDuplicateData
Scenario: Verify case sensitive duplicate Education record is not allowed for duplicate entry
#TC003 Add a Eucation with valid input, exisiting data with case sensitivity
   When user add json data from json file with entry <index>
	And user adds same record with case sensitivity from json file
  Then Verify duplicate case sensitive record is not allowed

	Examples:
	  | index |
	  | 0     | # first entry from Json file , to check with all valid fields
	
	@editEducationRecord
	Scenario: Edit Educaiton Record 
	#TC025 Edit the existing Education entry in the profile 
When user add json data from json file with entry <index>
And user edit a text field in the entry <index>
Then verify Education record is updated 

Examples: 
| index |
| 0     | # edit education record


	@removeEducationRecord
	Scenario: Remove Educaiton Record 
	#TC026 Remove the education entry in the profile 
When user add json data from json file with entry <index>
And user remove record with the entry <index>
Then verify education record is removed with <index>

Examples: 
| index |
| 0     | # remove education record