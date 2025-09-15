public class QuizService
{
    public QuizQuestion[] GetQuiz()
    {
        return new QuizQuestion[]
        {
            new QuizQuestion(
            1,
            "Hur hanterar du en ledig söndag utan planer?",
            new string[]{"Jag gör inget. Om möjligt, ännu mindre.", "Jag glor ut genom fösntret och låtsas tänka på livet.", "Jag organiserar om köksskåpen för fjärde gången. Det är tryggt.",
            "Planer?! Jag har redan cyklat, målat, sprungit och bakat bröd!", "Det är inte söndag förrän 02:00, då kickar jag igång."}
        ),
        new QuizQuestion(
            2,
            "Du får en inbjudan till en spontan fest ikväll. Vad gör du?",
            new string[]{"Ignorerar den. Har en relation med min filt", "Funderar på hur det känns att gå, men går inte. ", "Nej tack. Jag har ett schema och ett kvällste att respektera. ",
                "JA! Klart jag kommer! Kan jag ta med ett brädspel? ", "Kommer sent. Dansar konstigt. Går inte hem. "}
        ),
        new QuizQuestion(
            3,
            "Vad beskriver bäst din relation till teknik?",
            new string[]{"Jag använder fjärrkontrollen som armstöd. ", "Jag kollar YouTube-tutorials om grejer jag aldrig kommer göra. ",
                "Jag har lösenordshanterare, backuper och etiketter på alla kablar. ", "Jag har tre smarta högtalare och de bråkar med varandra. ", "Kod, AI och mörker. Allt funkar bättre efter midnatt. "}
        ),
        new QuizQuestion(
            4,
            "Vad gör du när du blir riktigt inspirerad?",
            new string[]{"Lägger mig ner tills känslan går över. ", "Skriver ett långt dokument jag aldrig öppnar igen. ", "Skapar en mappstruktur med färgkodning. ",
                "Startar ett projekt. Bygger en hemsida. Glömmer äta. ", "Skriver 14 idéer i Notion kl. 03:27. Alla börjar med “Tänk om…” "}
        ),
        new QuizQuestion(
            5,
            "Hur ser du på din sömn?",
            new string[]{"Det är min största passion och hobby. ", "Jag sover när hjärnan tillåter. Vilket den inte gör. ", "Jag har sovtid, sängtäcke, öronproppar och backup-kudde. ",
                "Sömn? Jag har inte tid. Jag har idéer. ", "Min dygnsrytm är ett konstprojekt. "}
        )
        };


    }

    public CatPersona[] GetCatPersonas()
    {
        return new CatPersona[]
            {
            new CatPersona(
            1,
            "The Purrplex",
            "En soffliggande mystiker som tycks vara i ständig existentiell vila. Misstas ofta för en kudde. Går bara upp om det brinner (kanske). Chillar på avancerad nivå.",
            new string[] { "Har GPS-positionerat varje mjuk yta i hemmet.", "Känner exakt skillnad på “mysljummet” och “perfekt temperatur",
                "Lägger sig på fjärrkontrollen men vägrar flytta." },
            "Jag är inte lat. Jag är i viloläge med stil."
            ),
            new CatPersona(
            2,
            "Paws N' Reflect",
            "Mästerlig betraktare. Sitter vid fönstret och dömer världen i tystnad. Rör sig inte i onödan – men vet exakt vad som händer på parkeringen. Har tankar. Djupa sådana.",
            new string[] { "Stirrar på ingenting i 40 minuter – sedan blinkar långsamt.", "Ser ut att tänka på universum, planerar förmodligen ett hopp på diskbänken.",
                "Reagerar bara på saker som flyger, glänser eller rör sig mystiskt." },
            "Jag ser allt. Jag gör inget."
            ),
              new CatPersona(
            3,
            "Boximus Prime",
            "En skuggälskande trygghetssamlare som lever efter devisen: ”Inga överraskningar är bra överraskningar.” Har sin plats, sin filt, sin rytm – och gärna också sin vägg bakom ryggen. Minimalist i det yttre, maximalist i sin zon.",
            new string[] { "Har en specifik plats i soffan – och den är helig.", "Går till samma ICA, samma kassa, varje gång.",
                "Tittar på The Office för fjärde gången för att den vet vad som händer." },
            "Jag gillar när livet känns som en mjuk låda. Med lock."
            ),
              new CatPersona(
            4,
            "The Zoomolog",
            "Har ett konstant överskottslager av energi. Ser en laserpunkt? Zoom. En skugga i ögonvrån? ZOOM. Fungerar som människa ungefär som en katt med jetpack – driven, spontan, men hopplös på att sitta still.",
            new string[] { "Går från “ligger ner” till “springer till köket” på 0.2 sekunder.", "•	Skriver meddelanden i CAPSLOCK utan att märka det.",
                "Börjar fem projekt på en gång – hinner klart… kanske ett?" },
            "Vad sa du? Nej men jag lyssnade. Eller alltså... jag trodde jag gjorde det. Så många bollar, så lite tid."

            ),
              new CatPersona(
            5,
            "The Midnight Whisker",
            "Blommar ut vid midnatt. När andra stänger ögonen öppnar Natt-Nisse Figma, YouTube, och sitt sjätte sinne. En nattlig kattvarelse med kreativ eld, kaosenergi och obegriplig dygnsrytm.",
            new string[] { "Dricker kaffe kl. 22 och tycker det är “lugnt”.", "Har byggt om hela sin portfolio mellan 01–04 – tre gånger.",
                "Svarar på mejl 03:37 och avslutar med “godmorgon”." },
            "Sömn är för svaga – eller väldigt strukturerade – själar."
            ),
        };
    }






    public QuizResult CalculateResult(SubmissionDto submission)
    {
        var catPersonas = GetCatPersonas();
        var scores = new Dictionary<string, int>();

        foreach (var persona in catPersonas)
        {
            scores[persona.Name] = 0;
        }

        foreach (var answer in submission.Answers)
        {
            switch (answer.QuestionId)
            {
                case 1:
                    switch (answer.OptionIndex)
                    {
                        case 0:
                            scores["The Purrplex"]++;
                            break;
                        case 1:
                            scores["Paws N' Reflect"]++;
                            break;
                        case 2:
                            scores["Boximus Prime"]++;
                            break;
                        case 3:
                            scores["The Zoomolog"]++;
                            break;
                        case 4:
                            scores["The Midnight Whisker"]++;
                            break;
                    }
                    break;
                case 2: 
                    switch (answer.OptionIndex)
                    {
                        case 0: scores["The Purrplex"]++; break;
                        case 1: scores["Paws N' Reflect"]++; break;
                        case 2: scores["Boximus Prime"]++; break;
                        case 3: scores["The Zoomolog"]++; break;
                        case 4: scores["The Midnight Whisker"]++; break;
                    }
                    break;

                case 3: 
                    switch (answer.OptionIndex)
                    {
                        case 0: scores["The Purrplex"]++; break;
                        case 1: scores["Paws N' Reflect"]++; break;
                        case 2: scores["Boximus Prime"]++; break;
                        case 3: scores["The Zoomolog"]++; break;
                        case 4: scores["The Midnight Whisker"]++; break;
                    }
                    break;

                case 4: 
                    switch (answer.OptionIndex)
                    {
                        case 0: scores["The Purrplex"]++; break;
                        case 1: scores["Paws N' Reflect"]++; break;
                        case 2: scores["Boximus Prime"]++; break;
                        case 3: scores["The Zoomolog"]++; break;
                        case 4: scores["The Midnight Whisker"]++; break;
                    }
                    break;

                case 5: 
                    switch (answer.OptionIndex)
                    {
                        case 0: scores["The Purrplex"]++; break;
                        case 1: scores["Paws N' Reflect"]++; break;
                        case 2: scores["Boximus Prime"]++; break;
                        case 3: scores["The Zoomolog"]++; break;
                        case 4: scores["The Midnight Whisker"]++; break;
                    }
                    break;


            }
        }
        var topPersona = scores.OrderByDescending(s => s.Value).First().Key;
        return new QuizResult(catPersonas.First(p => p.Name == topPersona), scores);

    }
}