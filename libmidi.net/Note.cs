using System;
using libmidi.net.Enums;
using System.Collections.Generic;

namespace libmidi.net
{
	public class Note
	{
		public List<MidiNote> Tones { get; private set;}
		public NoteType Type { get; private set;}
		public int Velocity { get; private set;}

		public Note(NoteType type, int velocity, params MidiNote[] tones)
		{
			Tones = new List<MidiNote>();
			Tones.AddRange(tones);
			Type = type;
			Velocity = velocity;
		}

		public override bool Equals(object obj)
		{
			return this == (Note)obj;
		}

		public override int GetHashCode()
		{
			int hash = 0;
			foreach(MidiNote note in Tones)
			{
				hash += (int)note;
			}

			hash += Velocity;
			hash += (int)Type;

			return hash;
		}

		public override string ToString()
		{
			string tones = "";
			foreach(MidiNote note in Tones)
			{
				tones += note.ToString() + ", ";
			}
			tones.Trim().TrimEnd(',');

			return string.Format("[Note: Tones={0}, Type={1}, Velocity={2}]", tones, Type, Velocity);
		}

		public static bool operator == (Note a, Note b)
		{
			if(a.Type != b.Type)
				return false;
			if(a.Velocity != b.Velocity)
				return false;
			if(a.Tones.Count != b.Tones.Count)
				return false;

			foreach(MidiNote noteB in b.Tones)
			{
				bool found = false;
				foreach(MidiNote noteA in a.Tones)
				{
					if(noteA == noteB)
					{
						found = true;
						break;
					}
				}

				if(found == false)
				{
					return false;
				}
			}

			return true;
		}

		public static bool operator != (Note a, Note b)
		{
			return !(a == b);
		}
	}
}

