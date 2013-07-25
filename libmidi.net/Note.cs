using System;
using libmidi.net.Enums;

namespace libmidi.net
{
	public class Note
	{
		public MidiNote Tone { get; private set;}
		public NoteType Type { get; private set;}
		public int Velocity { get; private set;}

		public Note(NoteType type, int velocity, MidiNote tone)
		{
			Tone = tone;
			Type = type;
			Velocity = velocity;
		}
	}
}

