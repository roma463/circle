using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class thead : MonoBehaviour
{
	private void Start()
	{
        MakeWork();
        var thead = new Thread(() => MakeWorke(1));
		//thead.Start();

	}
    Task<string> MakeWorkInThread()
	{
		var task = new Task<string>
			(
			() => { Thread.Sleep(5000); return "Completed"; }
			);
		print("0");
        task.Start();
		return task;
	}

	async public void MakeWork()
	{
		var labelText = await MakeWorkInThread();
		print(labelText);
	}
	private void MakeWorke(int x)
    {
		Thread.Sleep(5000);
		print($"all be back {x}");
    }
}
