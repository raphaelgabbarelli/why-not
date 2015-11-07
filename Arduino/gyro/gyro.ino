#include "Wire.h"
#include "I2Cdev.h"
#include "MPU6050.h"

// class default I2C address is 0x68
// specific I2C addresses may be passed as a parameter here
// AD0 low = 0x68 (default for InvenSense evaluation board)
// AD0 high = 0x69
MPU6050 accelgyro;

int16_t ax, ay, az, gx, gy, gz;

void setup() {
    Wire.begin();

    // initialize serial communication
    // (38400 chosen because it works as well at 8MHz as it does at 16MHz, but
    // it's really up to you depending on your project)
    Serial.begin(38400);

    accelgyro.initialize();

    // verify connection
    Serial.println("Testing device connections...");
    Serial.println(accelgyro.testConnection() ? "MPU6050 connection successful" : "MPU6050 connection failed");
}

void printNumber(int16_t number) {
    char tmp[5];
    sprintf(tmp, "%6d", number);
    //sprintf(tmp, "%0.4X", number);
    Serial.print(tmp); Serial.print(" ");
}

void loop() {
    accelgyro.getMotion6(&ax, &ay, &az, &gx, &gy, &gz);
    printNumber(ax);
    printNumber(ay);
    printNumber(az);
    printNumber(gx);
    printNumber(gy);
    printNumber(gz);
    Serial.println();
    delay(100);
}
