.NET Technical Task

Overview
In this exercise, you are required to create an ASP.NET Core solution using Visual
Studio (latest version if possible) that allows users to submit a temporary unique
string for a TopScore user, subject to specific format restrictions. The project should
utilise an SQLite database. The overall task consists of two main parts:
• String validation and data submission
• Data search functionality
Please create a production quality solution that is ready for peer review. We do not
expect you to write unit tests.
Package your solution into a ZIP archive excluding the 'bin' (executables) folder
and upload to a file storage solution of your choice. Alternatively, provide us access
to a Github repository.
Requirements
The solution should consist of two web pages:
1. Data Submission Page
• Contains a single empty text box and a submit button.
• Users enter a sentence into the text box.
• The system validates the input based on the format restrictions
mentioned in the String Validation & Assumptions sections.
• If the input passes validation, only the valid word (not the entire
sentence) should be entered into the SQLite database.
• If the word is already in the database, it should not be accepted
again.
2. Data Display Page
• Includes a search feature to find strings already in the database.

String Validation
The submitted string should adhere to the following format restrictions:
1. Must contain at least one uppercase letter, one lowercase letter, and one
number.
2. No character should be repeated.
3. Must be at least 8 characters long.
You are given a string S consisting of N characters. String S can be divided into
words by splitting it at, and removing, the spaces. The goal is to choose the longest
valid word from the string and return it. If multiple longest valid words are present,
return any one of them.
Example: Given the string "TopScore M HJkl6789 Qwerty123 Test One ", the
longest valid word is "Qwerty123".
Assumptions: • N is an integer within the range [1..500].
• String S consists only of alphanumeric characters and spaces.
• Regular expressions should not be used in the logic.
