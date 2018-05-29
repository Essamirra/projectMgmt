using System.Collections.Generic;


namespace projman_client.Views.ViewInterfaces
{
    public interface IEditTaskView
    {
        void ShowTask(Task task,  bool isEditEnabled, bool isAssignEnabled);
        void ShowTaskInEditMode(Task task);
        void ShowAssignDialog(List<User> options);
        void GoBack();
    }
}