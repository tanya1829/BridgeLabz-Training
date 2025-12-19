using System;
     class Operator {
         static void Main() {
	     int a= 5, b=10;
	    // Performing arithmetic operations
	  
	        // Addition
            Console.WriteLine("Sum is " + (a + b)); 
		 
		    // Subtraction
            Console.WriteLine("Subtraction is " + (a - b));
		 
		     // Multiplication
            Console.WriteLine("Multiplication is " + (a * b)); 
		 
		      // Division
            Console.WriteLine("Division is " + (a / b)); 
		 
		    //Modulus
            Console.WriteLine("Modulus is " + (a % b)); 
		 
		    // Increment
		    a++;
            Console.WriteLine(a);     

            // Decrement
             b--;
            Console.WriteLine(b);   
			
		// Performing Relational Operations
		    
			// Equal
		    Console.WriteLine(a == b); 
			
			// Not equal
            Console.WriteLine(a != b); 
			
			 // Greater than
            Console.WriteLine(a > b); 
			
			// Less than
            Console.WriteLine(a < b);  
			
			// Greater or equal
            Console.WriteLine(a >= b); 
			
			// Less or equal
            Console.WriteLine(a <= b); 
		
		//Performing Logical Operations
		    
			bool p = true, q = false;
			
            // AND
            Console.WriteLine(p && q); 
			
			// OR
            Console.WriteLine(p || q); 
			
			// NOT
            Console.WriteLine(!p);   
			
        // Performing Assignment Operator
		    
			int k = 10;

            k += 5;
            Console.WriteLine(k);

            k -= 2;
            Console.WriteLine(k);

            k *= 3;
            Console.WriteLine(k);

            k /= 4;
            Console.WriteLine(k);

            k %= 3;
           Console.WriteLine(k);

            k &= 2;
           Console.WriteLine(k);

           k |= 1;
           Console.WriteLine(k);

           k ^= 2;
           Console.WriteLine(k);

           k <<= 1;
           Console.WriteLine(k);

           k >>= 1;
          Console.WriteLine(k);
		  
		// Performing Unary operations
           int num = 5;
           
		   // Unary plus
           Console.WriteLine(+num); 
		   
		   // Unary minus
           Console.WriteLine(-num); 
		   
		   // Logical NOT
           Console.WriteLine(!true); 
		   
		   // Bitwise NOT
           Console.WriteLine(~num); 

           num++;
           Console.WriteLine(num);

           num--;
           Console.WriteLine(num);

           Console.WriteLine(typeof(int));  //  typeof
           
           Console.WriteLine(nameof(num));  //  nameof
		
        // Performing Ternary Operations
		   
		   int age = 18;

           string result = (age >= 18) ? "Adult" : "Minor";
           Console.WriteLine(result);
        
		// is and as operations 
		
		  object obj = "Hello";
  
          Console.WriteLine(obj is string);

          string s = obj as string;
		  
          Console.WriteLine(s);
		  
		 // TypeCasting Operation
		 
		 char y = (char) 22;
		 Console.WriteLine(y);
		 }
	 }