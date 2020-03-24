using System;
using System.Collections.ObjectModel;

public class Group
{
	private ObservableCollection<StudyGroup> Groups = new ObservableCollection<StudyGroup>();
	public Group()
	{
		
	}
	public void addStudyGroup(StudyGroup studyGroup)
	{
		this.Groups.Add(studyGroup);

	}
}
