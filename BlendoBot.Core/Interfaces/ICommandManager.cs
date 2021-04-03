using BlendoBot.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlendoBot.Core.Interfaces {
	/// <summary>
	/// Handles what commands are available, as well as other functionalities like listeners.
	/// </summary>
	public interface ICommandManager : IBotService {

		/// <summary>
		/// Adds a message listener to the program for this command.
		/// </summary>
		void AddMessageListener(object o, ulong guildId, IMessageListener messageListener);

		/// <summary>
		/// Removes a message listener from the program for this command.
		/// </summary>
		void RemoveMessageListener(object o, ulong guildId, IMessageListener messageListener);

		/// <summary>
		/// Adds a reaction listener to the program for this command.
		/// </summary>
		void AddReactionListener(object o, ulong guildId, ulong messageId, IReactionListener reactionListener);

		/// <summary>
		/// Removes a message listener from the program for this command.
		/// </summary>
		void RemoveReactionListener(object o, ulong guildId, ulong messageId, IReactionListener reactionListener);

		/// <summary>
		/// Gets an instance of a command for the given guildId.
		/// </summary>
		T GetCommand<T>(object o, ulong guildId) where T : BaseCommand;

		/// <summary>
		/// Gets the term used for the help command on a certain guild. This is what users would have to type to see
		/// the help for other commands.
		/// </summary>
		string GetHelpCommandTerm(object o, ulong guildId);

		/// <summary>
		/// Gets the term used for a specific command on a certain guild. This would most likely be the concatenation
		/// of the command prefix for the guild and the current rename of the command term. This is what users would
		/// have to type to invoke the command.
		/// </summary>
		string GetCommandTerm(object o, BaseCommand command);

		/// <summary>
		/// Gets the prefix used in front of all command terms on a certain guild. This may be
		/// <see cref="string.Empty"/>.
		/// </summary>
		string GetCommandPrefix(object o, ulong guildId);

		/// <summary>
		/// Gets the guild instance of a command that corresponds to a term. The term should not include the command
		/// prefix specified by the program. This should return null if the command does not exist.
		/// </summary>
		BaseCommand GetCommandByTerm(object o, ulong guildId, string term);

		/// <summary>
		/// Gets the guild instance of a command that corresponds to a guid. This should return null if the command does
		/// not exist.
		/// </summary>
		BaseCommand GetCommandByGuid(object o, ulong guildId, string guid);

		/// <summary>
		/// Returns a path that this command can use to store persistent data. The command should give this particular
		/// instance a unique path, and the path should exist after this call.
		/// </summary>
		string GetCommandInstanceDataPath(object o, BaseCommand command);

		/// <summary>
		/// Returns a path that this command can use to store persistent data. The command should give this particular
		/// instance the same path as every other instance of this command, and the path should exist after this call.
		/// </summary>
		string GetCommandCommonDataPath(object o, BaseCommand command);
	}
}
