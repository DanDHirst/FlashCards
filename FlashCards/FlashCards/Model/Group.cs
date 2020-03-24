using BasicNavigation;
using System;
using System.Collections.ObjectModel;

public class Group : BindableModelBase
{
	private ObservableCollection<StudyGroup> Groups = new ObservableCollection<StudyGroup>();
	public Group()
	{
		
	}
	public void addStudyGroup(StudyGroup studyGroup)
	{
		this.Groups.Add(studyGroup);

	}
	public ObservableCollection<StudyGroup>  getGroup()
	{
		return this.Groups;
	}
	public ObservableCollection<StudyGroup> getGroupNames()
	{

		return this.Groups;
	}

}
