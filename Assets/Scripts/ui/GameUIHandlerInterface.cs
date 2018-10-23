using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface GameUIHandlerInterface
{

	bool isSingle();
	bool isAllways();

	void Show();
	void UnShow();

    void Release();
    void ReleaseUnused();

    void Resize();
}
