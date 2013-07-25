using System;
using libmidi.net.Enums;

namespace libmidi.net
{
	public class Note
	{
		public MidiNote[] Tones { get; private set;}
		public NoteType Type { get; private set;}
		public int Velocity { get; private set;}

		public Note(NoteType type, int velocity, params MidiNote[] tones)
		{
			Tones = tones;
			Type = type;
			Velocity = velocity;
		}
	}
}

