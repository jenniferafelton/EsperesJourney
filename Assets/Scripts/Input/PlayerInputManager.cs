// Digx7
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputManager : MonoBehaviour {
    /* Description --
    *  This script will handel the player inputs using the new input manager package
    *  This should be what every thing else in the scene refrences when getting the player input
    */

    [SerializeField] private Player Player;                  // This references the input action map
    //[SerializeField] private Inventory inventory;
    //[SerializeField] private UI_Inventory uiInventory;
    
    [SerializeField] private Vector2 moveDirection;

    [SerializeField] private Vector2Event moveInput;
    [SerializeField] private UnityEvent attackInput;
    [SerializeField] private UnityEvent dashInput;
    [SerializeField] private UnityEvent healInput;
    [SerializeField] private UnityEvent InteractInput;
    [SerializeField] private UnityEvent InventoryInput;

    // --- Updates -------------------------------------

    public void Awake() {
        Player = new Player();             // This is needed to set up the input action map
        //inventory = new Inventory();
        //uiInventory.SetInventory(inventory);

        //ItemWorld.SpawnItemWorld(new Vector3(10, 2), new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
        
        BindInputs();
    }

    // --- Get/Set -------------------------------------

    private void setMoveDirection(Vector2 input){
      moveDirection = input;
      moveInput.Invoke(moveDirection);
    }

    public Vector2 getMoveDirection(){
      return moveDirection;
    }

    // --- Events -------------------------------------

    private void attackInputEvent(){
      attackInput.Invoke();
    }

    private void dashInputEvent(){
      dashInput.Invoke();
    }

    private void healInputEvent(){
      healInput.Invoke();
    }

    private void InteractInputEvent()
    {
        InteractInput.Invoke();
    }

    private void InventoryInputEvent()
    {
        InventoryInput.Invoke();
    }

    // --- BindingInputs ----------------------------------

    // This script will bind the inputs on the Input action map to the needed script
    public void BindInputs() {
        Player.Character.Move.performed += ctx => this.setMoveDirection(ctx.ReadValue<Vector2>()); // This permantly binds the given inputs to the script with no need for any update function
        Player.Character.Dash.performed += ctx => this.dashInputEvent();
        Player.Character.Attack.performed += ctx => this.attackInputEvent();
        Player.Character.Heal.performed += ctx => this.healInputEvent();
        Player.Character.Interact.performed += ctx => this.InteractInputEvent();
        Player.Character.Inventory.performed += ctx => this.InventoryInputEvent();
    }

    // --- Enable/Disable --------------------------------

    // This will enable the Input Action Map
    private void OnEnable() {
        Player.Enable();
    }

    // This will enable the Input Action Map
    private void OnDisable() {
        Player.Disable();
    }
}

[System.Serializable]
public class Vector2Event : UnityEvent<Vector2>
{
}
