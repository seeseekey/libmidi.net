using System;
using libmidi.net;
using libmidi.net.Events;
using libmidi.net.Enums;

namespace createMidi
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			MidiEventCollection eventCollection=new MidiEventCollection(1, 30);

			eventCollection.AddEvent(new NoteOnEvent(15, 1, MidiNote.C1, 100, 15), 1);
			eventCollection.AddEvent(new NoteOnEvent(30, 1, MidiNote.D1, 100, 15), 1);
			eventCollection.AddEvent(new NoteOnEvent(45, 1, MidiNote.E1, 100, 15), 1);
			eventCollection.AddEvent(new NoteOnEvent(60, 1, MidiNote.F1, 100, 15), 1);
			eventCollection.AddEvent(new NoteOnEvent(75, 1, MidiNote.G1, 100, 15), 1);

			for(int i=0; i<12; i++)
			{
			    eventCollection.AddEvent(new NoteOnEvent(90+i*15, 1, i*10, 100, 15), 1);
			}

			for(int i=0; i<12; i++)
			{
			    eventCollection.AddEvent(new NoteOnEvent(90+180+i*15, 1, 120-i*10, 100, 15), 1);
			}

			MidiFile.Export("test.mid", eventCollection);
		}
	}
}
