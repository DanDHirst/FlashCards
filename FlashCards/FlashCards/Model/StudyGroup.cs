using FlashCards.Model;
using System;
using System.Collections.ObjectModel;

public class StudyGroup : ObservableCollection<FlashCard>
{
	public string GroupTitle { get; private set; }
	public string GroupShortName { get; private set; }
/*	private ObservableCollection<FlashCard> flashcards = new ObservableCollection<FlashCard>();

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

	}*/


	public StudyGroup(string title, string shortname)
	{
		GroupTitle = title;
		GroupShortName = shortname;
	}

}
