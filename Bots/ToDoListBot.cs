using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

public class ToDoListBot : ActivityHandler
{
    private readonly ConversationState _conversationState;
    private const string ToDoListKey = "ToDoList";

    public ToDoListBot(ConversationState conversationState)
    {
        _conversationState = conversationState;
    }

    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
    {
        var userMessage = turnContext.Activity.Text?.Trim().ToLower();
        var accessor = _conversationState.CreateProperty<Dictionary<int, string>>(ToDoListKey);
        var toDoList = await accessor.GetAsync(turnContext, () => new Dictionary<int, string>(), cancellationToken);

        if (string.IsNullOrEmpty(userMessage))
        {
            await turnContext.SendActivityAsync(MessageFactory.Text("Please enter a valid command."), cancellationToken);
            return;
        }

        if (userMessage.StartsWith("add "))
        {
            // TODO
        }
        else if (userMessage.StartsWith("remove "))
        {
            // TODO
        }
        else if (userMessage == "list")
        {
            // TODO
        }
        else if (userMessage == "help")
        {
            await turnContext.SendActivityAsync(MessageFactory.Text("Available commands:\n- add <task description>\n- remove <task ID>\n- list\n- help"), cancellationToken);
        }
        else
        {
            await turnContext.SendActivityAsync(MessageFactory.Text("Invalid command. Type 'help' for a list of available commands."), cancellationToken);
        }

        // Save the updated state
        await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
    }
}
