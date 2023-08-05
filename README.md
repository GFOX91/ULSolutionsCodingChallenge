# ULSolutionsCodingChallenge

I began by first creating the solution with 3 different projects
  - ASP.NEt Core web Api
  - Class libary (business layer)
  - Xunit testing project 

Next I created the expression helper with an evaluate method, with a list of comments on how I was going to proceed with evaluation of the expression.

My approach going forward was to first write a failing test to cover the particular aspect of the method I wanted to ensure worked.

First I had to ensure that the expression provided was not null or empty if so I would throw an Arguement exception 

Then I checked that the string was in a the correct format (representative of a sum) using a regex expression if not I threw an exception.

I then ensured that if the expression contained any spaces that these were removed, (prior to the previous format check) this ensured that expressions could also be entered spaces with no issues during the caluclation.

After this I split the expression into a list of strings representative of the numbers and operators utilizing a regex string.

I declared a list of Operators in the order of BODMAS which i then iterated through In order to do the sums in the order of precident:

  - I would first get the index of the operator
  - retrieve the operator 
  - then retrieve the number to the left side of the operator using index-1
  - then retrieve the number to the right of the operator using index + 1
  - With these 3 parts of the sum retrieved I would caluclate the sum of their combination
  - After which I would remove the 3 parts of the sum just calulated and replace with the result of the calculation 

The iteration through each operator would continue until there was only one result left which would be the final calculation.

Once the tests were all passing I refactored the code and broke up into smaller more readable private methods to make more clean/ easier to follow.

I then added a controller which utilized the method in the expression helper, for this I first wrote tests to capture all the exceptions and ensure the 
relevant status codes were returned, I then ensured that the result was returned with the Ok status code, finally added some tags to the controller so 
that the swagger documentation provided more clarity
