using System;

public class StudyGroup
{
	private String name;
	private ObservableCollection<FlashCard> flashcards;

	public StudyGroup()
	{
	}
	
	public StudyGroup(ObservableCollection<FlashCard> flashcards)
	{
		this.flashcards = flashcards;
	}

	public void addFlashCard(FlashCard flashcards)
    {
		this.flashcards.add(flashcards);

	}


}
