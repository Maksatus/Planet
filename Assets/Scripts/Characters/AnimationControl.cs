using UnityEngine;

public class AnimationControl : MonoBehaviour
{
	[SerializeField] private Animator animator;
	
	private string _currentAnimation="";
	public void SetAnimation(string animationName){
		
		if (_currentAnimation != "") {
			animator.SetBool (_currentAnimation, false);
		}
		animator.SetBool (animationName, true);
		_currentAnimation = animationName;
	}
}
