using System;
class AtmDispenser{
    static void Main(){
        
        int [] totalNotes= {500,200,100,50,20,10,5,2,1};
        int sum=0;
        int targetValue=880;
        int notesCount=0;
        Console.WriteLine("Scenario 1 : 500 note is included ");
        for(int i=0; i<totalNotes.Length; i++){
            if(sum+totalNotes[i] <=targetValue){
                sum+=totalNotes[i];
                notesCount++;
                i--;
            }
        }
        Console.WriteLine("The number of notes :  " +  notesCount);
        Console.WriteLine("Scenario 2 : Without 500 note ");
        int [] MoneyArr={200,100,50,20,10,5,2,1};
        int summ =0;
        int targett=1880;
        int countValue=0;
        for(int i=0; i< MoneyArr.Length ;i++){
            if(summ+MoneyArr[i] <= targett){
                summ+= MoneyArr[i];
                countValue++;
                i--;
            }
        }   
        Console.WriteLine("The number of notes :  " +  countValue ); 
    }
}
