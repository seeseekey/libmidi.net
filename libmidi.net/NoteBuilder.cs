using System;
using libmidi.net;
using libmidi.net.Enums;
using libmidi.net.Events;
using libmidi.net.Base;

namespace libmidi.net
{
	public class NoteBuilder
	{
		MidiEventCollection events;
		int currentTime;

		const int pulsesPerQuarter = 96;

		public NoteBuilder(int bpm)
		{
			double microsecondsPerQuarternote = 60000000 / bpm;
			double oneTickFrequency = microsecondsPerQuarternote / 1000000 / pulsesPerQuarter;

			int microSecondsPerQuarterNode = (int)(pulsesPerQuarter * oneTickFrequency * 1000000.0);

			events=new MidiEventCollection(1, pulsesPerQuarter);
			events.AddEvent(new TempoEvent(microSecondsPerQuarterNode, 0), 0);

			currentTime = 0;
		}

		public void AddNotes(params Note[] notes)
		{
			int longestNoteType = 0;

			foreach(Note note in notes)
			{
				if((int)note.Type > longestNoteType) longestNoteType = (int)note.Type;
				events.AddEvent(new NoteOnEvent(currentTime, 1, note.Tone, 100, (int)(note.Type)), 1); //Note on
				events.AddEvent(new NoteOnEvent(currentTime+(int)note.Type, 1, note.Tone, 0, 0), 1); //Note off
			}

			currentTime+=longestNoteType;
		}

		public void Save(string filename)
		{
			events.PrepareForExport();
			MidiFile.Export(filename, events);
		}
	}
}

