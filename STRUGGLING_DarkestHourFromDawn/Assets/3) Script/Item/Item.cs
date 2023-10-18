using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type {EItem, CItem, SItem};
    public Type type;
    public int value;
}
