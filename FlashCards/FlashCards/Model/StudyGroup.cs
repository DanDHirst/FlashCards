using System;
using System.Collections.ObjectModel;

public class StudyGroup
{
	private String name;
	private ObservableCollection<FlashCard> flashcards = new ObservableCollection<FlashCard>();

	public StudyGroup()
	{
	}
	
	public StudyGroup(ObservableCollection<FlashCard> flashcards)
	{
		this.flashcards = flashcards;
	}

	public void addFlashCard(FlashCard flashcards)
    {
		this.flashcards.Add(flashcards);

	}


}
