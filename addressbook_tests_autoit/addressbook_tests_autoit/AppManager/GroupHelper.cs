using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager) : base (manager)
        {
            
        }

        public List<GroupData> GetGroupList()
        {
            Console.WriteLine("GetGroupList - начало");
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            Console.WriteLine("Открыто диалоговое окно групп");
            System.Threading.Thread.Sleep(2000);
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");

            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#" + i, "");
                list.Add(new GroupData() { Name = item });
            }
            CloseGroupsDialogue();

            return list;
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            Console.WriteLine("Перед нажатием на кнопку добавления группы");
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            System.Threading.Thread.Sleep(5000);
            aux.Send(newGroup.Name);
            System.Threading.Thread.Sleep(3000);
            aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialogue()
        {
            Console.WriteLine("Перед нажатием на кнопку открытия диалогового окна групп");
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512"); //тесты не нажимают на эту кнопку
            Console.WriteLine("Открыто диалоговое окно групп");
            // aux.WinWait(GROUPWINTITLE);
            aux.WinWait(GROUPWINTITLE);
            aux.WinActivate(GROUPWINTITLE);
            aux.WinWaitActive(GROUPWINTITLE);
        }
    }
}
