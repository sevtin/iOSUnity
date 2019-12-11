//
//  UnityInterface.h
//  UnityBridge
//
//  Created by saeipi on 2019/12/11.
//  Copyright © 2019 saeipi. All rights reserved.
//

#ifndef UnityInterface_h
#define UnityInterface_h

#include <stdio.h>
/*
 UnitySendMessage（“string”，“string”， ***），这是方法，我们至少需要传入两个参数，第一个参数为unity中的一个gameobject名称，第二个参数为这个gameobject身上捆绑的脚本中的一个方法，而第三参数事实上是这个对应方法上的参数，有没有参数就看你了。
 */
void UnitySendMessage(const char* obj, const char* method, const char* msg);
#endif /* UnityInterface_h */
