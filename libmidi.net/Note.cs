using System;
using libmidi.net.Enums;

namespace libmidi.net
{
	public class Note
	{
		public NoteType Type { get; private set;}
		public MidiNote Tone { get; private set;}

		public Note(NoteType type, MidiNote tone)
		{
			Type = type;
			Tone = tone;
		}
	}
}

