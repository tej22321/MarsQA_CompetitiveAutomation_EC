Feature: Adding Certification to a user profile 
	
	Background: 
	  Given user log into MarsQA
	  And navigate to Certification under profile tab


	@addCertification
	Scenario Outline: Add new certification entry from json data file to user profile
	# Authorised person, trying to add a certification entry to the profile 
	 When user add certification data from json file with entry <index>
	 Then Verify Certification record is created status is <expectedoutcome>

	 Examples:
	  | index | expectedoutcome |
	  | 0     | true            | #TC027 Authorised person, trying to add a Certification entry to the profile
	  | 2     | false           | #TC029 Authorised person, trying to add a invalid Certification entry to the profile , with numbers in Cerifcaition orAward filed
	  | 3     | false           | #TC030 Authorised person, trying to add a invalid Certification entry to the profile , with alphanumeric  in Cerifcaition orAward filed
	  | 4     | false           | #TC031 Authorised person, trying to add a invalid Certification entry to the profile , with special characters  in Cerifcaition orAward filed
	  | 5     | false           | #TC032 Authorised person, trying to add a invalid Certification entry to the profile , with empty field  in Cerifcaition orAward filed
	  | 6     | false           | #TC033 Authorised person, trying to add a invalid Certification entry to the profile , with Null   in Cerifcaition orAward filed
	  | 7     | false           | #TC034 Authorised person, trying to add a invalid Certification entry to the profile , with spaces in Cerifcaition orAward filed
	  | 8     | false           | #TC035 Authorised person, trying to add a invalid Certification entry to the profile , with numbers  in Certified From (e.g. Adobe) filed
	  | 9     | false           | #TC036 Authorised person, trying to add a invalid Certification entry to the profile , with specail characters in Certified From (e.g. Adobe) filed
	  | 10    | false           | #TC037 Authorised person, trying to add a invalid Certification entry to the profile , with alphanumeric  in Certified From (e.g. Adobe) filed
	  | 11    | false           | #TC038 Authorised person, trying to add a invalid Certification entry to the profile , with empty field in Certified From (e.g. Adobe) filed
	  | 12    | false           | #TC039 Authorised person, trying to add a invalid Certification entry to the profile , with spaces in Certified From (e.g. Adobe) filed
	  | 13    | false           | #TC040 Authorised person, trying to add a invalid Certification entry to the profile , with null value in Certified From (e.g. Adobe) filed
	  | 14    | true            | #TC041 Authorised person, trying to add a valid Certification entry to the profile , by selecting yearOfGraduation throguh  up and down arrow
	  | 15    | true            | #TC042 Authorised person, trying to add a valid Certification entry to the profile , by selecting yearOfGraduation by selecting a number 
	
	@checkDuplicate
Scenario: Verify duplicate Certification record is not allowed for duplicate entry
#TC028 Authorised person, trying to add a valid Certification entry to the profile with duplicate data 
   When user add certification data from json file with entry <index>
	And user adds same certification record again from json file of entry <index>
  Then Verify duplicate Certification record is not allowed

	Examples:
	  | index |
	  | 0     | # first entry from Json file , to check with all valid fields

	  

	   @caseSensitiveDuplicateData
Scenario: Verify case sensitive duplicate Education record is not allowed for duplicate entry
#TC029 Authorised person, trying to add a valid Certification entry to the profile with case senesituve duplicate data
   When user add certification data from json file with entry <index>
	And user adds same certification record with case sensitivity from json file
  Then Verify duplicate case sensitive record is not allowed
  
	Examples:
	  | index |
	  | 0     | # first entry from Json file , to check with all valid fields
	 

	 
	@removeCertificationRecord
	Scenario: Remove Certification Record 
	#TC043 remove the Certification entry in the profile 
 When user add certification data from json file with entry <index>
And user remove certification record with the entry <index>
Then verify certification record is removed with <index>

Examples: 
| index |
| 0     | # TC043 remove certification record

	
	@editCertificationRecord
	Scenario: Edit Certification Record 
	#TC044 Edit the existing Certification entry in the profile 
When user add certification data from json file with entry <index>
And user edit a text field in the certification entry <index>
Then verify Certification record is updated 

Examples: 
| index |
| 0     | # edit Certification record