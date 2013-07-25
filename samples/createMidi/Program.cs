using System;
using libmidi.net;
using libmidi.net.Events;
using libmidi.net.Enums;
using libmidi.net.Base;

namespace createMidi
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			MidiEventCollection eventCollection=new MidiEventCollection(1, 30);

			eventCollection.AddEvent(new NoteOnEvent(15, 1, MidiNote.C1, 100, 15), 1); //Note on
			eventCollection.AddEvent(new NoteOnEvent(15+100, 1, MidiNote.C1, 0, 0), 1); //Note off

			eventCollection.PrepareForExport();

			MidiFile.Export("test.mid", eventCollection);
		}
	}
}
