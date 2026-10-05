/*
* Filnamn: Program.cs
* Forfattare: Johanna Hassberg
* Datum: 2026-10-05
* Kurs: Programmering i C#
*
* Beskrivning: Uppgift 3. Konsollapplikation som är en gästbok. 
* Användaren ska kunna skriva inlägg i en gästbok och ta bort inlägg. 
* Inläggen ska sparas i en fil.
*/

// Huvudmetod som kör programmet
// Skapar en instans av Guestbook-klassen
using Uppgift3;

Guestbook guestbook = new Guestbook();
// Rensar konsolen vid start av programmet
Console.Clear();

// Loop som kör programmet tills användaren väljer att avsluta
while (true)
{
    Console.WriteLine("__________________________________");
    Console.WriteLine("MIN GÄSTBOK");
    Console.WriteLine("------------");
    Console.WriteLine("\n1. Skriv ett inlägg");
    Console.WriteLine("2. Ta bort inlägg");
    Console.WriteLine("\nX. Avsluta");
    Console.WriteLine("------------");
    Console.WriteLine("ALLA INLÄGG");


    int index = 0;
    // Visning av alla inlägg i gästboken med indexnummer
    foreach (GuestbookEntry guestEntry in guestbook.GetEntries())
    {
        Console.WriteLine($"[{index}] {guestEntry.UserName} skrev: {guestEntry.Entry}");
        index++;
    }

    Console.WriteLine("__________________________________");


    string choice = Console.ReadLine() ?? "";
    Console.WriteLine($"Du valde: {choice}");

    if (choice == "1")
    {
        Console.WriteLine("Skriv ett inlägg");

        bool validInput = false;
        string username = "";
        string entry = "";

        // Fortsätter att fråga användaren om namn och inlägg tills giltig input
        do
        {
            Console.Write("Ange namn: ");
            username = Console.ReadLine();

            // Kolla att användaren har angett ett namn
            if (username == null || username.Trim() == "")
            {
                Console.WriteLine("Du måste ange ett namn.");
                continue;
            }
            Console.Write("Ange inlägg: ");
            entry = Console.ReadLine();

            // Kolla att användaren har skrivit ett inlägg
            if (entry == null || entry.Trim() == "")
            {
                Console.WriteLine("Skriv ett inlägg.");
                continue;
            }

            validInput = true;

        } while (!validInput);

        // Lägger till inlägget i gästboken
        guestbook.AddEntry(username, entry);
        Console.Clear();
        Console.WriteLine("❤️ Ditt inlägg betyder mycket för mig och jag uppskattar att du tog dig tid att skriva det. Tack för att du delar med dig av dina tankar och känslor i gästboken! ❤️");


    }

    else if (choice == "2")
    {
        Console.WriteLine("Ta bort inlägg");
        Console.Write("Ange index på inlägget du vill ta bort: ");
        string indexInput = Console.ReadLine() ?? "";

        // Kolla att användaren har angett ett index
        if (!String.IsNullOrEmpty(indexInput))
        {
            try
            {
                // Försök att ta bort inlägget med det angivna indexet
                guestbook.DeleteEntry(Convert.ToInt32(indexInput));
                Console.Clear();
                Console.WriteLine("✔️ Inlägget har tagits bort.");
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("⚠️ Ogiltigt index. Vänligen mata in ett befintligt indexnummer.");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("⚠️ Du måste mata in ett nummer.");
        }
    }
    else if (choice.ToUpper() == "X")
    {
        // Avslutar programmet
        break;
    }
    else
    {
        // Ogiltigt val, fortsätt loopen
        Console.WriteLine("⚠️ Ogiltigt val. Försök igen.");
        continue;
    }
}
