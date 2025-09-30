
public class QuizService
{
  public QuizQuestion[] GetQuiz()
{
    return new[]
    {
        new QuizQuestion(
            1,
            "Your morning alarm goes off. What happens next?",
            new[]
            {
                "Snooze. Then negotiate a second snooze.",
                "Stare at the ceiling and reflect on time itself.",
                "Get up on schedule, make the bed with precision.",
                "I’m already up — stretches done, coffee brewing.",
                "“Morning” is a social construct. I’m going to bed now."
            }
        ),
        new QuizQuestion(
            2,
            "You have a free hour with nothing planned. What do you do?",
            new[]
            {
                "Burrito myself in a blanket and do absolutely nothing.",
                "Sit by a window and watch the world go by.",
                "Sort a drawer, tidy a shelf, restore order to the realm.",
                "Try three little activities in ten minutes, start a mini adventure.",
                "Save the hour for later—my day starts after dark."
            }
        ),
        new QuizQuestion(
            3,
            "A friend suggests a spontaneous outing right now.",
            new[]
            {
                "Thank you, but I’m in a committed relationship with my couch.",
                "I’ll think about it… and probably keep thinking.",
                "Can we schedule it for Thursday at 18:30?",
                "YES. Shoes on. Where are we going?",
                "See you tonight—much later tonight."
            }
        ),
        new QuizQuestion(
            4,
            "You’re suddenly feeling inspired.",
            new[]
            {
                "Lie down until the feeling passes.",
                "Write a few thoughtful lines in a notebook.",
                "Make a neat plan with steps and boxes to tick.",
                "Start immediately; I’ll figure it out while doing.",
                "Note the idea and revisit it at 02:00 with dramatic flair."
            }
        ),
        new QuizQuestion(
            5,
            "It’s time to relax after a long day. Your ideal vibe?",
            new[]
            {
                "Soft blanket, soft snacks, soft silence.",
                "Quiet corner, slow thoughts, maybe rainfall in the background.",
                "A familiar routine: tea, tidy, favorite rerun.",
                "Something lively—games, friends, movement, laughter.",
                "A moonlit walk, late music, night-owl magic."
            }
        )
    };
}



    public CatPersona[] GetCatPersonas()
    {
        return new[]
        {
        new CatPersona(
            1,
            "The Purrplex",
            "A couch-dwelling mystic in permanent existential idle. Often mistaken for a pillow. Gets up only if there's a fire (maybe). Chilling at an advanced level.",
            new[]
            {
                "Has GPS-marked every soft surface in the home.",
                "Detects the exact difference between “cozy-warm” and “perfect temperature”.",
                "Lies on the remote and refuses to move."
            },
            "I'm not lazy. I'm in stylish standby."
        ),
        new CatPersona(
            2,
            "Paws N' Reflect",
            "A master observer. Sits by the window and judges the world in silence. Moves only when necessary — yet knows exactly what's happening in the parking lot. Has thoughts. Deep ones.",
            new[]
            {
                "Stares at nothing for 40 minutes — then slow-blinks.",
                "Looks like they're pondering the universe; probably planning a jump onto the counter.",
                "Only reacts to things that fly, sparkle, or move mysteriously."
            },
            "I see everything. I do nothing."
        ),
        new CatPersona(
            3,
            "Boximus Prime",
            "A shadow-loving collector of safety who lives by: “No surprises are good surprises.” Has a spot, a blanket, a rhythm — and preferably a wall behind their back. Minimalist on the outside, maximalist in their zone.",
            new[]
            {
                "Has a specific spot on the couch — and it is sacred.",
                "Goes to the same grocery store, same checkout, every time.",
                "Watches The Office for the fourth time because they know what happens."
            },
            "I like life when it feels like a soft box. With a lid."
        ),
        new CatPersona(
            4,
            "The Zoomolog",
            "Runs on surplus energy. See a laser dot? Zoom. A shadow in the corner? ZOOM. Human equivalent of a cat with a jetpack — driven, spontaneous, hopeless at sitting still.",
            new[]
            {
                "Goes from lying down to sprinting to the kitchen in 0.2 seconds.",
                "Types messages in CAPS LOCK without noticing.",
                "Starts five projects at once — maybe finishes one?"
            },
            "What did you say? No, I was listening. Or… I thought I was. So many balls, so little time."
        ),
        new CatPersona(
            5,
            "The Midnight Whisker",
            "Blooms at midnight. When others close their eyes, Midnight opens Figma, YouTube, and a sixth sense. A nocturnal cat-being with creative fire, chaos energy, and an unreadable sleep cycle.",
            new[]
            {
                "Drinks coffee at 22:00 and calls it “fine”.",
                "Rebuilt the entire portfolio between 01:00–04:00 — three times.",
                "Replies to emails at 03:37 and signs off with “good morning”."
            },
            "Sleep is for the weak — or the extremely structured."
        )
    };
    }



    public QuizResult CalculateResult(SubmissionDto submission)
    {
        var catPersonas = GetCatPersonas();
        var personaNames = new[]
        {
        "The Purrplex",
        "Paws N' Reflect",
        "Boximus Prime",
        "The Zoomolog",
        "The Midnight Whisker"
    };

       
        var mapping = new Dictionary<int, int[]>
    {
        { 1, new[] { 0, 1, 2, 3, 4 } },
        { 2, new[] { 0, 1, 2, 3, 4 } },
        { 3, new[] { 0, 1, 2, 3, 4 } },
        { 4, new[] { 0, 1, 2, 3, 4 } },
        { 5, new[] { 0, 1, 2, 3, 4 } },
    };

        
        var scores = personaNames.ToDictionary(name => name, _ => 0);

        if (submission?.Answers is not { Length: > 0 })
            return new QuizResult(catPersonas.First(), scores); 

        foreach (var answer in submission.Answers)
        {
            if (!mapping.TryGetValue(answer.QuestionId, out var personaIndexByOption))
                continue; 

            if (answer.OptionIndex < 0 || answer.OptionIndex >= personaIndexByOption.Length)
                continue; 

            var personaIdx = personaIndexByOption[answer.OptionIndex];

            if (personaIdx < 0 || personaIdx >= personaNames.Length)
                continue; 

            var personaName = personaNames[personaIdx];
            scores[personaName]++;
        }

        
        var max = scores.Values.DefaultIfEmpty(0).Max();
        var winners = scores.Where(kv => kv.Value == max).Select(kv => kv.Key).ToList();

        
        var topName = winners.OrderBy(name => Array.IndexOf(personaNames, name)).First();

        return new QuizResult(catPersonas.First(p => p.Name == topName), scores);
    }
}