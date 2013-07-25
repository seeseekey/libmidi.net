using System;
using libmidi.net;
using libmidi.net.Enums;

namespace createMidiWithNoteBuilder
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			NoteBuilder builder = new NoteBuilder(120);

			builder.Add(new Note(NoteType.Quarter, 100, MidiNote.C4));
			builder.Add(new Note(NoteType.Quarter, 50, MidiNote.D4));
			builder.Add(new Note(NoteType.Quarter, 50, MidiNote.E4));
			builder.Add(new Note(NoteType.Quarter, 100, MidiNote.F4));

			builder.Add(new Note(NoteType.Half, 127, Chords.CDur));
			builder.Add(new Note(NoteType.Half, 127, Chords.CMoll));

			builder.Save("test.mid");
		}
	}
}
