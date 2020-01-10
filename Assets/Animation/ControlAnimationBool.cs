using UnityEngine;
using UnityEngine.InputSystem;

using System.Reflection;

public class ControlAnimationBool : MonoBehaviour
{
	Animator animator;
	PlayerInput playerInput;

	public string ParamName;

	public void ToggleParam()
	{
		Debug.Log($"MethodBase.GetCurrentMethod().Name on object \"{name}\"");
		if (!LogIfNoAnimator())
		{
			return;
		}	

		bool bValue = animator.GetBool(ParamName);
		bool bNewValue = !bValue;
		Debug.Log($"Togging param \"{ParamName}\" to new value: {bNewValue}");
		animator.SetBool(ParamName, bNewValue);
	}

	void Awake()
	{
		animator = GetComponent<Animator>();
		playerInput = GetComponent<PlayerInput>();
		InitializeInputActions();
		LogIfNoAnimator();
	}

	void InitializeInputActions()
	{
		InputAction toggleBool = playerInput.actions["ToggleBool"];

		if(toggleBool != null)
		{
			toggleBool.started += ToggleBool_started;
			toggleBool.performed += ToggleBool_performed;
			toggleBool.canceled += ToggleBool_canceled;
		}
		else
		{
			Debug.LogError($"\"ToggleBool\" action is not binded");
		}
	}

	void ToggleBool_started(InputAction.CallbackContext context)
	{
		Debug.Log($"MethodBase.GetCurrentMethod().Name on object \"{name}\"");
		ToggleParam();
	}

	void ToggleBool_performed(InputAction.CallbackContext context)
	{
		Debug.Log($"MethodBase.GetCurrentMethod().Name on object \"{name}\"");
	}

	void ToggleBool_canceled(InputAction.CallbackContext context)
	{
		Debug.Log($"MethodBase.GetCurrentMethod().Name on object \"{name}\"");
	}

	bool LogIfNoAnimator()
	{
		if (animator == null)
		{
			Debug.LogError($"No animator attached to object named \"{name}\"");
			return false;
		}
		return true;
	}
}
